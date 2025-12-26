namespace SistemaVendas.Froms
{
    partial class TelaPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipal));
            panel1 = new Panel();
            bntRelatorio = new Button();
            bntVenda = new Button();
            bntProduto = new Button();
            bntCliente = new Button();
            panelForm = new Panel();
            textBox1 = new TextBox();
            panel1.SuspendLayout();
            panelForm.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(bntRelatorio);
            panel1.Controls.Add(bntVenda);
            panel1.Controls.Add(bntProduto);
            panel1.Controls.Add(bntCliente);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1265, 92);
            panel1.TabIndex = 0;
            // 
            // bntRelatorio
            // 
            bntRelatorio.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            bntRelatorio.Image = (Image)resources.GetObject("bntRelatorio.Image");
            bntRelatorio.Location = new Point(589, 0);
            bntRelatorio.Name = "bntRelatorio";
            bntRelatorio.Size = new Size(220, 92);
            bntRelatorio.TabIndex = 3;
            bntRelatorio.Text = "Relatório";
            bntRelatorio.TextAlign = ContentAlignment.MiddleLeft;
            bntRelatorio.TextImageRelation = TextImageRelation.ImageBeforeText;
            bntRelatorio.UseVisualStyleBackColor = true;
            bntRelatorio.Click += bntRelatorio_Click;
            // 
            // bntVenda
            // 
            bntVenda.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            bntVenda.Image = (Image)resources.GetObject("bntVenda.Image");
            bntVenda.Location = new Point(385, 0);
            bntVenda.Name = "bntVenda";
            bntVenda.Size = new Size(209, 92);
            bntVenda.TabIndex = 2;
            bntVenda.Text = "Vendas";
            bntVenda.TextAlign = ContentAlignment.MiddleLeft;
            bntVenda.TextImageRelation = TextImageRelation.ImageBeforeText;
            bntVenda.UseVisualStyleBackColor = true;
            bntVenda.Click += bntVenda_Click;
            // 
            // bntProduto
            // 
            bntProduto.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            bntProduto.Image = (Image)resources.GetObject("bntProduto.Image");
            bntProduto.Location = new Point(173, 0);
            bntProduto.Name = "bntProduto";
            bntProduto.Size = new Size(214, 92);
            bntProduto.TabIndex = 1;
            bntProduto.Text = "Produto";
            bntProduto.TextAlign = ContentAlignment.MiddleLeft;
            bntProduto.TextImageRelation = TextImageRelation.ImageBeforeText;
            bntProduto.UseVisualStyleBackColor = true;
            bntProduto.Click += bntProduto_Click;
            // 
            // bntCliente
            // 
            bntCliente.Dock = DockStyle.Left;
            bntCliente.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            bntCliente.Image = (Image)resources.GetObject("bntCliente.Image");
            bntCliente.Location = new Point(0, 0);
            bntCliente.Name = "bntCliente";
            bntCliente.Size = new Size(175, 92);
            bntCliente.TabIndex = 0;
            bntCliente.Text = "Cliente";
            bntCliente.TextAlign = ContentAlignment.MiddleLeft;
            bntCliente.TextImageRelation = TextImageRelation.ImageBeforeText;
            bntCliente.UseVisualStyleBackColor = true;
            bntCliente.Click += bntCliente_Click;
            // 
            // panelForm
            // 
            panelForm.Controls.Add(textBox1);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(0, 92);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1265, 648);
            panelForm.TabIndex = 1;
            panelForm.Paint += panelForm_Paint;
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            textBox1.Location = new Point(290, 169);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(650, 36);
            textBox1.TabIndex = 0;
            textBox1.Text = "Controle de Vendas";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1265, 740);
            Controls.Add(panelForm);
            Controls.Add(panel1);
            ForeColor = SystemColors.MenuHighlight;
            Name = "TelaPrincipal";
            Text = "TelaPrincipal";
            Load += TelaPrincipal_Load;
            panel1.ResumeLayout(false);
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button bntProduto;
        private Button bntCliente;
        private Button bntVenda;
        private Panel panelForm;
        private Button bntRelatorio;
        private TextBox textBox1;
    }
}