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
            bntVenda = new Button();
            bntProduto = new Button();
            bntCliente = new Button();
            panelForm = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(bntVenda);
            panel1.Controls.Add(bntProduto);
            panel1.Controls.Add(bntCliente);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1265, 92);
            panel1.TabIndex = 0;
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
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(0, 92);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1265, 648);
            panelForm.TabIndex = 1;
            panelForm.Paint += panelForm_Paint;
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
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button bntProduto;
        private Button bntCliente;
        private Button bntVenda;
        private Panel panelForm;
    }
}