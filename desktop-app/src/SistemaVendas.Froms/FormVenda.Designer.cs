namespace SistemaVendas.Froms
{
    partial class frmVendas
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
            label1 = new Label();
            label2 = new Label();
            groupBoxProduto = new GroupBox();
            dtDataVenda = new DateTimePicker();
            cbClientes = new ComboBox();
            dataGridViewItensVenda = new DataGridView();
            ProdutoId = new DataGridViewTextBoxColumn();
            ProdutoNome = new DataGridViewTextBoxColumn();
            Quantidade = new DataGridViewTextBoxColumn();
            Preco = new DataGridViewTextBoxColumn();
            Subtotal = new DataGridViewTextBoxColumn();
            groupBoxListProdutos = new GroupBox();
            bntCancelar = new Button();
            bntFinalizarVenda = new Button();
            lblTotal = new Label();
            cbProdutos = new ComboBox();
            groupBox1 = new GroupBox();
            bntAdicionarProduto = new Button();
            nudPreco = new NumericUpDown();
            label6 = new Label();
            nudQuantidade = new NumericUpDown();
            label7 = new Label();
            label8 = new Label();
            groupBoxProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItensVenda).BeginInit();
            groupBoxListProdutos.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPreco).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantidade).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 32);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(76, 28);
            label1.TabIndex = 4;
            label1.Text = "Cliente:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 86);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(57, 28);
            label2.TabIndex = 5;
            label2.Text = "Data:";
            // 
            // groupBoxProduto
            // 
            groupBoxProduto.Controls.Add(dtDataVenda);
            groupBoxProduto.Controls.Add(cbClientes);
            groupBoxProduto.Controls.Add(label1);
            groupBoxProduto.Controls.Add(label2);
            groupBoxProduto.Location = new Point(31, 12);
            groupBoxProduto.Name = "groupBoxProduto";
            groupBoxProduto.Size = new Size(1219, 128);
            groupBoxProduto.TabIndex = 7;
            groupBoxProduto.TabStop = false;
            groupBoxProduto.Text = "Cliente";
            // 
            // dtDataVenda
            // 
            dtDataVenda.Location = new Point(96, 80);
            dtDataVenda.Name = "dtDataVenda";
            dtDataVenda.Size = new Size(324, 34);
            dtDataVenda.TabIndex = 15;
            // 
            // cbClientes
            // 
            cbClientes.FormattingEnabled = true;
            cbClientes.Location = new Point(96, 32);
            cbClientes.Name = "cbClientes";
            cbClientes.Size = new Size(324, 36);
            cbClientes.TabIndex = 14;
            // 
            // dataGridViewItensVenda
            // 
            dataGridViewItensVenda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewItensVenda.Columns.AddRange(new DataGridViewColumn[] { ProdutoId, ProdutoNome, Quantidade, Preco, Subtotal });
            dataGridViewItensVenda.Location = new Point(6, 28);
            dataGridViewItensVenda.Name = "dataGridViewItensVenda";
            dataGridViewItensVenda.RowHeadersWidth = 51;
            dataGridViewItensVenda.Size = new Size(1079, 157);
            dataGridViewItensVenda.TabIndex = 8;
          
            // 
            // ProdutoId
            // 
            ProdutoId.HeaderText = "ProdutoId";
            ProdutoId.MinimumWidth = 6;
            ProdutoId.Name = "ProdutoId";
            ProdutoId.Visible = false;
            ProdutoId.Width = 300;
            // 
            // ProdutoNome
            // 
            ProdutoNome.HeaderText = "Produto";
            ProdutoNome.MinimumWidth = 6;
            ProdutoNome.Name = "ProdutoNome";
            ProdutoNome.Width = 300;
            // 
            // Quantidade
            // 
            Quantidade.HeaderText = "Quantidade";
            Quantidade.MinimumWidth = 6;
            Quantidade.Name = "Quantidade";
            Quantidade.Width = 125;
            // 
            // Preco
            // 
            Preco.HeaderText = "Preço";
            Preco.MinimumWidth = 6;
            Preco.Name = "Preco";
            Preco.Width = 300;
            // 
            // Subtotal
            // 
            Subtotal.HeaderText = "Subtotal";
            Subtotal.MinimumWidth = 6;
            Subtotal.Name = "Subtotal";
            Subtotal.Width = 300;
            // 
            // groupBoxListProdutos
            // 
            groupBoxListProdutos.Controls.Add(bntCancelar);
            groupBoxListProdutos.Controls.Add(bntFinalizarVenda);
            groupBoxListProdutos.Controls.Add(lblTotal);
            groupBoxListProdutos.Controls.Add(dataGridViewItensVenda);
            groupBoxListProdutos.Location = new Point(31, 322);
            groupBoxListProdutos.Name = "groupBoxListProdutos";
            groupBoxListProdutos.Size = new Size(1218, 433);
            groupBoxListProdutos.TabIndex = 9;
            groupBoxListProdutos.TabStop = false;
            groupBoxListProdutos.Text = "Itens da Venda";
            // 
            // bntCancelar
            // 
            bntCancelar.Location = new Point(343, 329);
            bntCancelar.Name = "bntCancelar";
            bntCancelar.Size = new Size(113, 41);
            bntCancelar.TabIndex = 14;
            bntCancelar.Text = "Cancelar";
            bntCancelar.UseVisualStyleBackColor = true;
            // 
            // bntFinalizarVenda
            // 
            bntFinalizarVenda.Location = new Point(45, 329);
            bntFinalizarVenda.Name = "bntFinalizarVenda";
            bntFinalizarVenda.Size = new Size(197, 41);
            bntFinalizarVenda.TabIndex = 13;
            bntFinalizarVenda.Text = "Finalizar Venda";
            bntFinalizarVenda.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(20, 224);
            lblTotal.Margin = new Padding(4, 0, 4, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(58, 28);
            lblTotal.TabIndex = 11;
            lblTotal.Text = "Total:";
            // 
            // cbProdutos
            // 
            cbProdutos.FormattingEnabled = true;
            cbProdutos.Location = new Point(127, 25);
            cbProdutos.Name = "cbProdutos";
            cbProdutos.Size = new Size(177, 36);
            cbProdutos.TabIndex = 15;
            cbProdutos.SelectedIndexChanged += cbProdutos_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(bntAdicionarProduto);
            groupBox1.Controls.Add(nudPreco);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(nudQuantidade);
            groupBox1.Controls.Add(cbProdutos);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Location = new Point(30, 146);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1219, 170);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Produto";
            // 
            // bntAdicionarProduto
            // 
            bntAdicionarProduto.Location = new Point(63, 134);
            bntAdicionarProduto.Name = "bntAdicionarProduto";
            bntAdicionarProduto.Size = new Size(180, 30);
            bntAdicionarProduto.TabIndex = 18;
            bntAdicionarProduto.Text = "Adicionar Produto";
            bntAdicionarProduto.UseVisualStyleBackColor = true;
            bntAdicionarProduto.Click += btnAdicionarProduto_Click;
            // 
            // nudPreco
            // 
            nudPreco.Location = new Point(496, 23);
            nudPreco.Name = "nudPreco";
            nudPreco.Size = new Size(143, 34);
            nudPreco.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(355, 28);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(171, 28);
            label6.TabIndex = 16;
            label6.Text = "Preço do Produto:";
            // 
            // nudQuantidade
            // 
            nudQuantidade.Location = new Point(127, 77);
            nudQuantidade.Name = "nudQuantidade";
            nudQuantidade.Size = new Size(177, 34);
            nudQuantidade.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(29, 79);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(115, 28);
            label7.TabIndex = 11;
            label7.Text = "Quantidade";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(29, 31);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(88, 28);
            label8.TabIndex = 10;
            label8.Text = "Produto:";
            // 
            // frmVendas
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1281, 779);
            Controls.Add(groupBox1);
            Controls.Add(groupBoxListProdutos);
            Controls.Add(groupBoxProduto);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "frmVendas";
            Text = "Produtos";
            Load += frmVendas_Load;
            groupBoxProduto.ResumeLayout(false);
            groupBoxProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItensVenda).EndInit();
            groupBoxListProdutos.ResumeLayout(false);
            groupBoxListProdutos.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPreco).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantidade).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Label label2;
        private GroupBox groupBoxProduto;
        private DataGridView dataGridViewItensVenda;
        private GroupBox groupBoxListProdutos;
        private ComboBox cbProdutos;
        private ComboBox cbClientes;
        private GroupBox groupBox1;
        private NumericUpDown nudPreco;
        private Label label6;
        private NumericUpDown nudQuantidade;
        private Label label7;
        private Label label8;
        private Button bntAdicionarProduto;
        private Button bntCancelar;
        private Button bntFinalizarVenda;
        private Label lblTotal;
        private DateTimePicker dtDataVenda;
        private DataGridViewTextBoxColumn ProdutoId;
        private DataGridViewTextBoxColumn ProdutoNome;
        private DataGridViewTextBoxColumn Quantidade;
        private DataGridViewTextBoxColumn Preco;
        private DataGridViewTextBoxColumn Subtotal;
    }
}
