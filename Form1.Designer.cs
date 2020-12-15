namespace FindNumers
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_start = new System.Windows.Forms.Button();
            this.num_target = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_generations = new System.Windows.Forms.Label();
            this.dtg_vectors = new System.Windows.Forms.DataGridView();
            this.grp_parameters = new System.Windows.Forms.GroupBox();
            this.chk_notRepeat = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.num_numberMaxGenerations = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.num_numberOffprings = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.num_numbersVector = new System.Windows.Forms.NumericUpDown();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.lbl_msj = new System.Windows.Forms.Label();
            this.chk_keepFathers = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.num_target)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_vectors)).BeginInit();
            this.grp_parameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_numberMaxGenerations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_numberOffprings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_numbersVector)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(450, 19);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(162, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Iniciar";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // num_target
            // 
            this.num_target.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_target.Location = new System.Drawing.Point(518, 138);
            this.num_target.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.num_target.Name = "num_target";
            this.num_target.Size = new System.Drawing.Size(94, 22);
            this.num_target.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(406, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cifra Objetivo:";
            // 
            // lbl_generations
            // 
            this.lbl_generations.AutoSize = true;
            this.lbl_generations.Location = new System.Drawing.Point(3, 142);
            this.lbl_generations.Name = "lbl_generations";
            this.lbl_generations.Size = new System.Drawing.Size(79, 13);
            this.lbl_generations.TabIndex = 3;
            this.lbl_generations.Text = "Generaciones: ";
            // 
            // dtg_vectors
            // 
            this.dtg_vectors.AllowUserToAddRows = false;
            this.dtg_vectors.AllowUserToDeleteRows = false;
            this.dtg_vectors.AllowUserToOrderColumns = true;
            this.dtg_vectors.AllowUserToResizeColumns = false;
            this.dtg_vectors.AllowUserToResizeRows = false;
            this.dtg_vectors.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtg_vectors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_vectors.Location = new System.Drawing.Point(3, 166);
            this.dtg_vectors.Name = "dtg_vectors";
            this.dtg_vectors.ReadOnly = true;
            this.dtg_vectors.RowHeadersVisible = false;
            this.dtg_vectors.Size = new System.Drawing.Size(609, 321);
            this.dtg_vectors.TabIndex = 4;
            // 
            // grp_parameters
            // 
            this.grp_parameters.Controls.Add(this.chk_keepFathers);
            this.grp_parameters.Controls.Add(this.chk_notRepeat);
            this.grp_parameters.Controls.Add(this.label4);
            this.grp_parameters.Controls.Add(this.num_numberMaxGenerations);
            this.grp_parameters.Controls.Add(this.label3);
            this.grp_parameters.Controls.Add(this.num_numberOffprings);
            this.grp_parameters.Controls.Add(this.label2);
            this.grp_parameters.Controls.Add(this.num_numbersVector);
            this.grp_parameters.Location = new System.Drawing.Point(6, 11);
            this.grp_parameters.Name = "grp_parameters";
            this.grp_parameters.Size = new System.Drawing.Size(424, 100);
            this.grp_parameters.TabIndex = 5;
            this.grp_parameters.TabStop = false;
            this.grp_parameters.Text = "Parámetros";
            // 
            // chk_notRepeat
            // 
            this.chk_notRepeat.AutoSize = true;
            this.chk_notRepeat.Location = new System.Drawing.Point(239, 71);
            this.chk_notRepeat.Name = "chk_notRepeat";
            this.chk_notRepeat.Size = new System.Drawing.Size(72, 17);
            this.chk_notRepeat.TabIndex = 11;
            this.chk_notRepeat.Text = "No repetir";
            this.chk_notRepeat.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Número de generaciones:";
            // 
            // num_numberMaxGenerations
            // 
            this.num_numberMaxGenerations.Location = new System.Drawing.Point(145, 24);
            this.num_numberMaxGenerations.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.num_numberMaxGenerations.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_numberMaxGenerations.Name = "num_numberMaxGenerations";
            this.num_numberMaxGenerations.Size = new System.Drawing.Size(75, 20);
            this.num_numberMaxGenerations.TabIndex = 10;
            this.num_numberMaxGenerations.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Número de crías:";
            // 
            // num_numberOffprings
            // 
            this.num_numberOffprings.Location = new System.Drawing.Point(145, 67);
            this.num_numberOffprings.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.num_numberOffprings.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_numberOffprings.Name = "num_numberOffprings";
            this.num_numberOffprings.Size = new System.Drawing.Size(75, 20);
            this.num_numberOffprings.TabIndex = 8;
            this.num_numberOffprings.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Números por cría:";
            // 
            // num_numbersVector
            // 
            this.num_numbersVector.Location = new System.Drawing.Point(344, 25);
            this.num_numbersVector.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.num_numbersVector.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_numbersVector.Name = "num_numbersVector";
            this.num_numbersVector.Size = new System.Drawing.Size(75, 20);
            this.num_numbersVector.TabIndex = 6;
            this.num_numbersVector.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btn_stop
            // 
            this.btn_stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_stop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stop.Location = new System.Drawing.Point(450, 52);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(162, 23);
            this.btn_stop.TabIndex = 6;
            this.btn_stop.Text = "Parar";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.Location = new System.Drawing.Point(450, 89);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(162, 23);
            this.btn_reset.TabIndex = 7;
            this.btn_reset.Text = "Resetear";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // lbl_msj
            // 
            this.lbl_msj.AutoSize = true;
            this.lbl_msj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_msj.Location = new System.Drawing.Point(187, 139);
            this.lbl_msj.Name = "lbl_msj";
            this.lbl_msj.Size = new System.Drawing.Size(20, 16);
            this.lbl_msj.TabIndex = 8;
            this.lbl_msj.Text = "...";
            // 
            // chk_keepFathers
            // 
            this.chk_keepFathers.AutoSize = true;
            this.chk_keepFathers.Location = new System.Drawing.Point(344, 71);
            this.chk_keepFathers.Name = "chk_keepFathers";
            this.chk_keepFathers.Size = new System.Drawing.Size(73, 17);
            this.chk_keepFathers.TabIndex = 12;
            this.chk_keepFathers.Text = "m. Padres";
            this.chk_keepFathers.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(616, 490);
            this.Controls.Add(this.lbl_msj);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.grp_parameters);
            this.Controls.Add(this.dtg_vectors);
            this.Controls.Add(this.lbl_generations);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.num_target);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encontrar tantos números que sumen..";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_target)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_vectors)).EndInit();
            this.grp_parameters.ResumeLayout(false);
            this.grp_parameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_numberMaxGenerations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_numberOffprings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_numbersVector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.NumericUpDown num_target;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_generations;
        private System.Windows.Forms.DataGridView dtg_vectors;
        private System.Windows.Forms.GroupBox grp_parameters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown num_numbersVector;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown num_numberOffprings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown num_numberMaxGenerations;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label lbl_msj;
        private System.Windows.Forms.CheckBox chk_notRepeat;
        private System.Windows.Forms.CheckBox chk_keepFathers;
    }
}

