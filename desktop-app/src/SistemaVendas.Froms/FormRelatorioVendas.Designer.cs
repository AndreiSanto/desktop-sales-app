namespace SistemaVendas.Froms
{
    partial class FormRelatorioVendas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dtInicio = new DateTimePicker();
            dtFim = new DateTimePicker();
            bntGerar = new Button();
            SuspendLayout();
            // 
            // dtInicio
            // 
            dtInicio.Location = new Point(100, 70);
            dtInicio.Name = "dtInicio";
            dtInicio.Size = new Size(254, 23);
            dtInicio.TabIndex = 0;
            // 
            // dtFim
            // 
            dtFim.Location = new Point(435, 70);
            dtFim.Name = "dtFim";
            dtFim.Size = new Size(254, 23);
            dtFim.TabIndex = 1;
            // 
            // bntGerar
            // 
            bntGerar.Location = new Point(731, 425);
            bntGerar.Name = "bntGerar";
            bntGerar.Size = new Size(146, 44);
            bntGerar.TabIndex = 2;
            bntGerar.Text = "Gerar Relatorio";
            bntGerar.UseVisualStyleBackColor = true;
            bntGerar.Click += bntGerar_Click;
            // 
            // FormRelatorioVendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 511);
            Controls.Add(bntGerar);
            Controls.Add(dtFim);
            Controls.Add(dtInicio);
            Name = "FormRelatorioVendas";
            Text = "FormRelatorioVendas";
            Load += FormRelatorioVendas_Load;
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dtInicio;
        private DateTimePicker dtFim;
        private Button bntGerar;
    }
}