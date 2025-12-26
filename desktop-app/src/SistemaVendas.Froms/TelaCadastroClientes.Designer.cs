namespace SistemaVendas.Froms
{
    partial class frmClientes
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
            txtEmail = new TextBox();
            txtTelefone = new TextBox();
            btnNovo = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            groupBoxCliente = new GroupBox();
            btnLimpar = new Button();
            btnExcluir = new Button();
            btnSalvar = new Button();
            dataGridViewClientes = new DataGridView();
            groupBoxListCliente = new GroupBox();
            groupBoxCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientes).BeginInit();
            groupBoxListCliente.SuspendLayout();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Location = new Point(107, 52);
            txtNome.Margin = new Padding(4);
            txtNome.Name = "txtNome";
            txtNome.ShortcutsEnabled = false;
            txtNome.Size = new Size(247, 29);
            txtNome.TabIndex = 0;
            txtNome.Tag = "";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(107, 107);
            txtEmail.Margin = new Padding(4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(247, 29);
            txtEmail.TabIndex = 1;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(107, 163);
            txtTelefone.Margin = new Padding(4);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(247, 29);
            txtTelefone.TabIndex = 2;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(86, 251);
            btnNovo.Margin = new Padding(4);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(135, 48);
            btnNovo.TabIndex = 3;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 52);
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
            label2.Location = new Point(28, 110);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(54, 21);
            label2.TabIndex = 5;
            label2.Text = "E-mail";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 166);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(67, 21);
            label3.TabIndex = 6;
            label3.Text = "Telefone";
            // 
            // groupBoxCliente
            // 
            groupBoxCliente.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxCliente.Controls.Add(btnLimpar);
            groupBoxCliente.Controls.Add(btnExcluir);
            groupBoxCliente.Controls.Add(btnSalvar);
            groupBoxCliente.Controls.Add(btnNovo);
            groupBoxCliente.Controls.Add(label1);
            groupBoxCliente.Controls.Add(label3);
            groupBoxCliente.Controls.Add(txtTelefone);
            groupBoxCliente.Controls.Add(txtNome);
            groupBoxCliente.Controls.Add(label2);
            groupBoxCliente.Controls.Add(txtEmail);
            groupBoxCliente.Location = new Point(25, 12);
            groupBoxCliente.Name = "groupBoxCliente";
            groupBoxCliente.Size = new Size(1225, 331);
            groupBoxCliente.TabIndex = 7;
            groupBoxCliente.TabStop = false;
            groupBoxCliente.Text = "Cliente";
            // 
            // btnLimpar
            // 
            btnLimpar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLimpar.Location = new Point(567, 251);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(135, 48);
            btnLimpar.TabIndex = 9;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            btnExcluir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExcluir.Location = new Point(408, 251);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(135, 48);
            btnExcluir.TabIndex = 8;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalvar.Location = new Point(251, 251);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(135, 48);
            btnSalvar.TabIndex = 7;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // dataGridViewClientes
            // 
            dataGridViewClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClientes.Dock = DockStyle.Fill;
            dataGridViewClientes.Location = new Point(3, 25);
            dataGridViewClientes.Name = "dataGridViewClientes";
            dataGridViewClientes.Size = new Size(1218, 366);
            dataGridViewClientes.TabIndex = 8;
            dataGridViewClientes.CellClick += dataGridViewClientes_CellClick;
            dataGridViewClientes.CellContentClick += dataGridViewClientes_CellContentClick;
            // 
            // groupBoxListCliente
            //
            groupBoxListCliente.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            groupBoxListCliente.Controls.Add(dataGridViewClientes);
            groupBoxListCliente.Location = new Point(25, 361);
            groupBoxListCliente.Name = "groupBoxListCliente";
            groupBoxListCliente.Size = new Size(1224, 394);
            groupBoxListCliente.TabIndex = 9;
            groupBoxListCliente.TabStop = false;
            groupBoxListCliente.Text = "Lista de Clientes";
            groupBoxListCliente.Enter += groupBox2_Enter;
            // 
            // frmClientes
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1281, 779);
            Controls.Add(groupBoxListCliente);
            Controls.Add(groupBoxCliente);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "frmClientes";
            Text = "Clientes";
            Load += frmClientes_Load;
            groupBoxCliente.ResumeLayout(false);
            groupBoxCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientes).EndInit();
            groupBoxListCliente.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtNome;
        private TextBox txtEmail;
        private TextBox txtTelefone;
        private Button btnNovo;
        private Label label1;
        private Label label2;
        private Label label3;
        private GroupBox groupBoxCliente;
        private Button btnSalvar;
        private Button btnLimpar;
        private Button btnExcluir;
        private DataGridView dataGridViewClientes;
        private GroupBox groupBoxListCliente;
    }
}
