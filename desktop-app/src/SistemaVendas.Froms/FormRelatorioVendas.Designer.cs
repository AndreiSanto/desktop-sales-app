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
            label1 = new Label();
            groupBox1 = new GroupBox();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dtInicio
            // 
            dtInicio.Location = new Point(92, 61);
            dtInicio.Name = "dtInicio";
            dtInicio.Size = new Size(254, 23);
            dtInicio.TabIndex = 0;
            // 
            // dtFim
            // 
            dtFim.Location = new Point(499, 61);
            dtFim.Name = "dtFim";
            dtFim.Size = new Size(254, 23);
            dtFim.TabIndex = 1;
            // 
            // bntGerar
            // 
            bntGerar.Location = new Point(704, 368);
            bntGerar.Name = "bntGerar";
            bntGerar.Size = new Size(146, 44);
            bntGerar.TabIndex = 2;
            bntGerar.Text = "Gerar Relatorio";
            bntGerar.UseVisualStyleBackColor = true;
            bntGerar.Click += bntGerar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 61);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 3;
            label1.Text = "Data Inicio:";
            label1.Click += label1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dtInicio);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dtFim);
            groupBox1.Location = new Point(39, 22);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(811, 328);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Gerar Relatório";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(436, 67);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 5;
            label2.Text = "Data Fim:";
            // 
            // FormRelatorioVendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 511);
            Controls.Add(groupBox1);
            Controls.Add(bntGerar);
            Name = "FormRelatorioVendas";
            Text = "FormRelatorioVendas";
            Load += FormRelatorioVendas_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dtInicio;
        private DateTimePicker dtFim;
        private Button bntGerar;
        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
    }
}