using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindNumers
{
    public partial class Form1 : Form
    { 
        /// <summary>
        /// Proyecto basado en Algoritmos Evolutivos para charla en Universidad Reformada 18-sep-2020
        /// Javier Quintero Ramírez 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        #region Properties

        private Random Ran = new Random();
        private int nGenerations; //Contador del número de generaciones.
        private int nMaxGenerations; //Indica el número máximo de iteraciones que se ejecutará el algoritmo 
        private int nOffspring; //Número de crías o descendientes que se crean en cada cruce de vectores.
        private int nNumbers; //Cantidad de números que contendrá cada vector       
        private decimal target; //Cifra exacta que la suma de todos los números de cada vector deben alcanzar
        private decimal maxScore; //Indica el puntaje que llevca cada vector.
        private bool evolutionGO = true; //Indica si el vector debe continuar o parar.               

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            SetParameters();
        }

        /// <summary>
        /// Valores por defecto que se asigan a los controles
        /// </summary>
        private void SetParameters()
        {
            num_target.Value = 100;
            num_numbersVector.Value = 5;
            num_numberMaxGenerations.Value = 100;
            num_numberOffprings.Value = 10;
            chk_notRepeat.Checked = false;
            chk_keepFathers.Checked = false;
            lbl_msj.Text = "...";
            lbl_generations.Text = "Generaciones: ";
            maxScore = 100;
        }

        /// <summary>
        /// Se inicia aquí el proceso del algoritmo evolutivo.
        /// </summary>        
        private void btn_start_Click(object sender, EventArgs e)
        {
            //Se capturan los valores establecidos en la interfaz gráfica

            //Se valida que se haya establecido un número mayor a cero por buscar.
            target = (int)num_target.Value;            
            if (target <= 0)
            {
                MessageBox.Show("Digite una cifra objetivo mayor que cero.");
                return;
            }

            //Se valida que la cifra objetivo sea igual o mayor a la cantidad de números del vector.
            nNumbers = (int)num_numbersVector.Value;
            if (target < nNumbers)
            {
                MessageBox.Show("La cifra objetivo debe ser igual o mayor que la cantidad de números del vector.");
                return;
            }

            nOffspring = (int)num_numberOffprings.Value;            
            nMaxGenerations = (int)num_numberMaxGenerations.Value;
            nGenerations = 0;

            //Se obtiene la población inicial de vectores
            var iniPopulation = InitialPopulation();

            //Se inicia el Algorito Evolutivo
            GeneticAlgorithm(iniPopulation);
        }

        /// <summary>
        /// Se crea la población inicial de vectores de manera aleatoria.
        /// Se crean tantos como se establezca el el parámetro nOffspring, con la cantidad de números que se asignen por le parámetro nNumbers.
        /// </summary>        
        private List<Vector> InitialPopulation()
        {
            List<Vector> Vecs = new List<Vector>();

            for (int i = 0; i < nOffspring; i++)
            {
                Vector Vec = new Vector();
                Vec.Numbers = new List<int>();

                for (int j = 0; j < nNumbers; j++)
                {
                    //Los números aleatores que se crean no deben superar el 50% del valor objetivo.
                    var r = Ran.Next(1, (int)target / 2);
                    Vec.Numbers.Add(Ran.Next(1, r));
                }
                Vecs.Add(Vec);
            }
            return Vecs;
        }

        /// <summary>
        /// Desde este método se "Comanda" todo el proceso del algoritmo genético.
        /// Se crea la población inicial se inicia el proceso iterativo, en el cual
        /// se evalúa la población, se selecciona, se cruzan los mejores ejemplares y se repite el proceso.
        /// </summary>
        /// <param name="Vecs">Vectores pertenencientes a la población inicial</param>
        private void GeneticAlgorithm(List<Vector> Vecs)
        {
            //Se da habilitación al proceso
            evolutionGO = true;

            //Se bloquean los controles de la interfaz gráfica
            SetParameters(evolutionGO);

            //Ciclo que se repetirá hasta que se cumpla alguno de los motivos de parada del algoritmo
            do
            {
                //Conteo de las generaciones.
                nGenerations++; 

                //Se obtienen los vectores con su calificación                
                var popEvaluated = EvaluatePopulation(Vecs);

                //Se crea un datatable a partir de los vectores creado y se muestran en el datagridview
                var dt = SetViewDataTable(popEvaluated);
                SetDataGridView(dt);

                //Se obtienen los dos mejores vectores, seleccionados según su porcentaje de adaptación.                
                var popSelected = SelectPopulation(popEvaluated);

                // Se evalúan las dos condiciones automáticas de parada del algoritmo:
                // 1. Que uno de los vectores alcance el 100 por ciento de adaptación.
                // 2. Que se alcance el número máximo de generaciones establecidas por parámetro.
                // La tercera condición de parada es manual, dada por el usuario en tiempo de ejecución.
                if (popSelected.Select(s => s.AdaptationPorcentage).Max() == maxScore 
                    || nMaxGenerations <= nGenerations)
                { 
                    evolutionGO = false;                    
                }                

                //Si no se cumpla ninguna condicón de parada, se toma una nueva población a partir del cruce de los mejores individuos.
                if (evolutionGO) { Vecs = Vector.DeepClone(CrossPopulation(popSelected)); }                
            }
            while (evolutionGO);

            SetParameters(evolutionGO);
        }        

        /// <summary>
        /// Sobre cada vector se calcula su porcentaje de adaptación
        /// en relación a qué tan cerca está de alcanzar el número objetivo.
        /// </summary>
        /// <param name="Vecs"></param>
        /// <returns></returns>
        private List<Vector> EvaluatePopulation(List<Vector> Vecs)
        {
            foreach (var vec in Vecs)
            {
                bool repeated = false;

                //Se verifica que el vector no tenga números repetidos, si es del caso.
                if (chk_notRepeat.Checked)
                {                    
                    foreach (var n in vec.Numbers)
                    {
                        if (vec.Numbers.Count(c => c == n) > 1)
                        {
                            vec.AdaptationPorcentage = 0;
                            repeated = true;
                            break;
                        }
                    }
                }


                //Si no tiene elementos repetidos, se calcula su calificación
                if (!repeated)
                {
                    vec.Sum = vec.Numbers.Sum();
                    var diff = Math.Abs(target - vec.Sum);
                    var pDiff = diff * 100 / target;
                    var adap = maxScore - pDiff;
                    vec.AdaptationPorcentage = Math.Round(adap, 2);
                }
            }
            return Vecs;
        }

        /// <summary>
        /// Se selecciona a los dos mejores individuos según su porcentaje de adaptación
        /// </summary>
        /// <param name="Vecs"></param>
        /// <returns></returns>
        private List<Vector> SelectPopulation(List<Vector> Vecs)
        {
            var v = Vecs.OrderByDescending(o => o.AdaptationPorcentage).Take(2).ToList();
            return v;
        }

        /// <summary>
        /// Se cruzan los dos mejores vectores de la última generación.
        /// El proceso consiste en crear diez vectores nuevos a partir de los dos Padres seleccionados...
        /// Aleatoriamente se toman números de uno u otro padre para crear la nueva generación.
        /// Aleatoriamente, uno de estos números puede cambiarse por otro o sumarle o restarle el 10% de su valor.
        /// Adicionalmenete, se conserva a los padres en la nueva generación con el fin de no perder los mejores 
        /// individuos en en cruzamientio que resulte poco favorecido por la suerte.
        /// </summary>
        /// <param name="Vecs">Dos mejores vectores seleccionados de la generación anterior</param>
        /// <returns></returns>
        private List<Vector> CrossPopulation(List<Vector> Vecs)
        {
            //Se clonan los dos meejores individuos de la generación anterior
            var father1 = Vector.DeepClone(Vecs[0]);
            var father2 = Vector.DeepClone(Vecs[1]);
            GC.Collect();
            GC.WaitForPendingFinalizers();

            List<Vector> newGenerationVectors = new List<Vector>();

            //Se incluyen los padres en la nueva generación si se habilita.
            if (chk_keepFathers.Checked)
            {
                newGenerationVectors.Add(father1);
                newGenerationVectors.Add(father2);
            }

            for (int i = 0; i < nOffspring; i++)
            {
                Vector childVector = new Vector();
                childVector.Numbers = new List<int>();
                
                for (int j = 0; j < nNumbers; j++)
                {
                    var r = Convert.ToBoolean(Ran.Next(0, 2));

                    //Se da un 50% de posibilidad a cada padre para heredar su número al nuevo individuo que se está creando.
                    if (r)
                    {
                        var n = Mutations(father1.Numbers[j]);
                        childVector.Numbers.Add(n);
                    }
                    else
                    {
                        var n = Mutations(father2.Numbers[j]);
                        childVector.Numbers.Add(n);
                    }
                }
                newGenerationVectors.Add(childVector);
            }
            return newGenerationVectors;
        }

        /// <summary>
        /// Se establec un 5% de probabilidad para que el número cambie:
        /// Un 1% de probabilidad para que se cambie por un número totalmente nuevo.
        /// Un 4% de probabilidad para que al número en cuestión se le sume o reste un 10% de su mismo valor.
        /// </summary>
        /// <param name="n">Número sometido a probabilidad de mutación</param>
        /// <returns></returns>
        private int Mutations(int n)
        {
            var x = n;
            var y = Ran.Next(0, 100);
            
            ///5% de Probabilidad de mutación...
            if (y <= 4)
            {
                //1% de probabilidad para obtener un número totalmente nuevo
                if (y == 0) 
                {   
                    x = Ran.Next(1, (int)target / 2);
                }
                else
                {
                    //4% de probabilidad para que al número actual se  le reste o sume un 10% de su valor.
                    var tenPor = n * 0.1;

                    if (y >= 3) { x = n + (int)Math.Truncate(tenPor); }
                    else  { x = n - (int)Math.Truncate(tenPor); }
                }
            }
            return x;
        }
        #region UI

        /// <summary>
        /// El datagridview recibe el datatable creado a partir del listado de vectores de cada generación.
        /// </summary>
        /// <param name="dt"></param>
        private void SetDataGridView(DataTable dt)
        {
            dtg_vectors.DataSource = null;
            dtg_vectors.DataSource = dt;
            dtg_vectors.AutoResizeColumns();
            lbl_generations.Text = "Generaciones: " + nGenerations.ToString();

            if (dtg_vectors.Rows.Count > 0) { dtg_vectors.Rows[0].Selected = false; }
            Application.DoEvents();
        }
       
        /// <summary>
        /// Se bloquen los controles cuando se ejecuta el algoritmo
        /// </summary>
        /// <param name="go"></param>
        private void SetParameters(bool go)
        {
            if (go)
            {
                grp_parameters.Enabled = false;
                btn_reset.Enabled = false;
                btn_start.Enabled = false;
                lbl_msj.Text = "";
            }
            else
            {
                grp_parameters.Enabled = true;
                btn_reset.Enabled = true;
                btn_start.Enabled = true;
                lbl_msj.Text = "No se encontró  :(";

                //Se resaltan los vectores que hayan alcanzado el 100% de adaptación
                foreach (DataGridViewRow r in dtg_vectors.Rows)
                {
                    if (r.Cells["% Adaptación"].Value.ToString() == maxScore.ToString())
                    {
                        r.Selected = true;
                        lbl_msj.Text = "¡Encontrado!";
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Se crea un datatable con el contenido de los vectores y su porcentaje de adaptación
        /// </summary>
        /// <param name="Vecs"></param>
        /// <returns></returns>
        public DataTable SetViewDataTable(List<Vector> Vecs)
        {
            try
            {
                DataTable dt = new DataTable();
                DataRow dr;

                DataColumn Index = new DataColumn() { ColumnName = "N° Cría" };
                dt.Columns.Add(Index);

                for (int i = 1; i <= nNumbers; i++)
                {
                    DataColumn c = new DataColumn();
                    c.ColumnName = i.ToString() + "°";
                    dt.Columns.Add(c);
                }

                DataColumn Fit = new DataColumn() { ColumnName = "% Adaptación" };
                dt.Columns.Add(Fit);

                int j = 1;
                foreach (var vec in Vecs)
                {
                    int k = 1;
                    
                    dr = dt.NewRow();
                    dr.SetField(0, j.ToString());                                        
                    
                    foreach (var n in vec.Numbers)
                    {                        
                        dr.SetField(k, n.ToString());
                        k++;
                    }

                    dr.SetField(nNumbers + 1, vec.AdaptationPorcentage.ToString());

                    dt.Rows.Add(dr);
                    j++;
                }             

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        private void btn_reset_Click(object sender, EventArgs e)
        {
            dtg_vectors.DataSource = null;
            SetParameters();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            evolutionGO = false;
            Application.DoEvents();
        }

        #endregion
    }

    /// <summary>
    /// Clase del vector que contendrá los números que deben sumar la cifra objetivo
    /// </summary>
    [Serializable()]
    public class Vector
    { 
        /// <summary>
        /// Vector de números enteros que deben alcanzar la cifra objetivo
        /// </summary>
        public List<int> Numbers { get; set; }
        /// <summary>
        /// Cifra resultado de la suma de todos los números que contiene el vector.
        /// </summary>
        public int Sum { get; set; }
        /// <summary>
        /// Porcentaje de adaptación de cada vector en relación a la cercanía a la cifra objetivo.
        /// </summary>
        public decimal AdaptationPorcentage { get; set; }
        /// <summary>
        /// Este método hace posible clonar las instancias de esta clase 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
