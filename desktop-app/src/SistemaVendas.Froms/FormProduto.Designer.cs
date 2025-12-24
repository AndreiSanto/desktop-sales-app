namespace SistemaVendas.Froms
{
    partial class frmProdutos
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private async void InitializeComponent()
        {
            txtNome = new TextBox();
            txtDescricao = new TextBox();
            label1 = new Label();
            label2 = new Label();
            groupBoxProduto = new GroupBox();
            nudEstoque = new NumericUpDown();
            nudPreco = new NumericUpDown();
            label5 = new Label();
            label4 = new Label();
            btnLimpar = new Button();
            btnExcluir = new Button();
            btnSalvar = new Button();
            dataGridViewProdutos = new DataGridView();
            groupBoxListProdutos = new GroupBox();
            groupBoxProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudEstoque).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPreco).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutos).BeginInit();
            groupBoxListProdutos.SuspendLayout();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Location = new Point(119, 29);
            txtNome.Margin = new Padding(4);
            txtNome.Name = "txtNome";
            txtNome.ShortcutsEnabled = false;
            txtNome.Size = new Size(247, 29);
            txtNome.TabIndex = 0;
            txtNome.Tag = "";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(119, 80);
            txtDescricao.Margin = new Padding(4);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(280, 29);
            txtDescricao.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 32);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(53, 21);
            label1.TabIndex = 4;
            label1.Text = "Nome";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 83);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(77, 21);
            label2.TabIndex = 5;
            label2.Text = "Descrição";
            label2.Click += label2_Click;
            // 
            // groupBoxProduto
            // 
            groupBoxProduto.Controls.Add(nudEstoque);
            groupBoxProduto.Controls.Add(nudPreco);
            groupBoxProduto.Controls.Add(label5);
            groupBoxProduto.Controls.Add(label4);
            groupBoxProduto.Controls.Add(btnLimpar);
            groupBoxProduto.Controls.Add(btnExcluir);
            groupBoxProduto.Controls.Add(btnSalvar);
            groupBoxProduto.Controls.Add(label1);
            groupBoxProduto.Controls.Add(txtNome);
            groupBoxProduto.Controls.Add(label2);
            groupBoxProduto.Controls.Add(txtDescricao);
            groupBoxProduto.Location = new Point(31, 12);
            groupBoxProduto.Name = "groupBoxProduto";
            groupBoxProduto.Size = new Size(1219, 229);
            groupBoxProduto.TabIndex = 7;
            groupBoxProduto.TabStop = false;
            groupBoxProduto.Text = "Produto";
            // 
            // nudEstoque
            // 
            nudEstoque.Location = new Point(605, 69);
            nudEstoque.Name = "nudEstoque";
            nudEstoque.Size = new Size(166, 29);
            nudEstoque.TabIndex = 13;
            // 
            // nudPreco
            // 
            nudPreco.Location = new Point(605, 25);
            nudPreco.Name = "nudPreco";
            nudPreco.Size = new Size(166, 29);
            nudPreco.TabIndex = 12;
            nudPreco.ValueChanged += nudPreco_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(533, 77);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(65, 21);
            label5.TabIndex = 11;
            label5.Text = "Estoque";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(533, 25);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(49, 21);
            label4.TabIndex = 10;
            label4.Text = "Preço";
            label4.Click += label4_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(605, 158);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(135, 48);
            btnLimpar.TabIndex = 9;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(447, 158);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(135, 48);
            btnExcluir.TabIndex = 8;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(294, 158);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(135, 48);
            btnSalvar.TabIndex = 7;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // dataGridViewProdutos
            // 
            dataGridViewProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProdutos.Location = new Point(0, 118);
            dataGridViewProdutos.Name = "dataGridViewProdutos";
            dataGridViewProdutos.Size = new Size(1212, 364);
            dataGridViewProdutos.TabIndex = 8;
            dataGridViewProdutos.CellClick += dataGridViewProdutos_CellClick;
            dataGridViewProdutos.CellContentClick += dataGridViewProdutos_CellContentClick;
            // 
            // groupBoxListProdutos
            // 
            groupBoxListProdutos.Controls.Add(dataGridViewProdutos);
            groupBoxListProdutos.Location = new Point(31, 267);
            groupBoxListProdutos.Name = "groupBoxListProdutos";
            groupBoxListProdutos.Size = new Size(1218, 488);
            groupBoxListProdutos.TabIndex = 9;
            groupBoxListProdutos.TabStop = false;
            groupBoxListProdutos.Text = "Lista de Produtos";
            groupBoxListProdutos.Enter += groupBox2_Enter;
            // 
            // frmProdutos
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1281, 779);
            Controls.Add(groupBoxListProdutos);
            Controls.Add(groupBoxProduto);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "frmProdutos";
            Text = "Produtos";
            Load += frmProdutos_Load;
            groupBoxProduto.ResumeLayout(false);
            groupBoxProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudEstoque).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPreco).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutos).EndInit();
            groupBoxListProdutos.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtNome;
        private TextBox txtDescricao;
        private Label label1;
        private Label label2;
        private GroupBox groupBoxProduto;
        private Button btnSalvar;
        private Button btnLimpar;
        private Button btnExcluir;
        private DataGridView dataGridViewProdutos;
        private GroupBox groupBoxListProdutos;
        private Label label4;
        private Label label5;
        private NumericUpDown nudEstoque;
        private NumericUpDown nudPreco;
    }
}
