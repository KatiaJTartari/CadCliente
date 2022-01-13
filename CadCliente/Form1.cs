using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CadCliente
{
    public partial class Form1 : Form
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        string strSQL;
        string mensagem = "";
        int confirmaCpf;

        public Form1()
        {
            InitializeComponent();
        }


        private void btnGravar_Click(object sender, EventArgs e)
        {
            //Mensagem de validação do CPF 
            string valor = mskCpf.Text;
            if (CadCliente.ValidaCpf.IsCpf(valor))
            {
                mensagem = "O número é um CPF Válido !";
                confirmaCpf = 1;
            }
            else
            {
                mensagem = "O número é um CPF Inválido !";
                confirmaCpf = 0;
            }
            MessageBox.Show(mensagem, "Validação");

            try
            {
                if (confirmaCpf == 1)
                {

                    conexao = new MySqlConnection("Server=localhost;Database=cadClientebd;Uid=root;Pwd=KatiaJT38;");

                    //Inserção dos dados
                    strSQL = "INSERT INTO CLIENTE (NOME, CPF, CEP, ENDERECO, NUMERO, COMPLEMENTO, TELEFONE) " +
                        "VALUES (@NOME, @CPF, @CEP, @ENDERECO, @NUMERO, @COMPLEMENTO, @TELEFONE)";

                    comando = new MySqlCommand(strSQL, conexao);
                    comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                    comando.Parameters.AddWithValue("@CPF", mskCpf.Text);
                    comando.Parameters.AddWithValue("@CEP", mskCep.Text);
                    comando.Parameters.AddWithValue("@ENDERECO", txtEndereco.Text);
                    comando.Parameters.AddWithValue("@NUMERO", txtNumero.Text);
                    comando.Parameters.AddWithValue("@COMPLEMENTO", txtComplemento.Text);
                    comando.Parameters.AddWithValue("@TELEFONE", mskTelefone.Text);

                    //Desabilita os campos do formulário após inserir/gravar os dados
                    txtCodigo.Text = "";
                    txtNome.Text = "";
                    mskCpf.Text = "";
                    mskCep.Text = "";
                    txtEndereco.Text = "";
                    txtNumero.Text = "";
                    txtComplemento.Text = "";
                    mskTelefone.Text = "";

                    conexao.Open();

                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
                MessageBox.Show("Cliente inserido com sucesso!");
            }
        }


        //Mascara para seleção de número de telefone celular ou fixo
        private void mskTelefone_TextChanged(object sender, EventArgs e)
        {
            if ("9".Equals(mskTelefone.Text.Substring(4, 1)))
            {
                mskTelefone.Mask = "(00)00000-0000";
            }
            else
            {
                mskTelefone.Mask = "(00)0000-0000";
            }
        }

        private void mskTelefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (mskTelefone.Text.Length != mskTelefone.Mask.Length)
                mskTelefone.ResetText();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=localhost;Database=cadClientebd;Uid=root;Pwd=KatiaJT38;");

                strSQL = "UPDATE CLIENTE SET NOME = @NOME, CPF = @CPF, CEP = @CEP, ENDERECO = @ENDERECO, " +
                    "NUMERO = @NUMERO, COMPLEMENTO = @COMPLEMENTO, TELEFONE = @TELEFONE WHERE CODIGO = @CODIGO";
                  
                comando = new MySqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@CODIGO", txtCodigo.Text);
                comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                comando.Parameters.AddWithValue("@CPF", mskCpf.Text);
                comando.Parameters.AddWithValue("@CEP", mskCep.Text);
                comando.Parameters.AddWithValue("@ENDERECO", txtEndereco.Text);
                comando.Parameters.AddWithValue("@NUMERO", txtNumero.Text);
                comando.Parameters.AddWithValue("@COMPLEMENTO", txtComplemento.Text);
                comando.Parameters.AddWithValue("@TELEFONE", mskTelefone.Text);

                conexao.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
                MessageBox.Show("Cliente editado com sucesso!");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=localhost;Database=cadClientebd;Uid=root;Pwd=KatiaJT38;");

                strSQL = "DELETE FROM CLIENTE WHERE CODIGO = @CODIGO";

                comando = new MySqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@CODIGO", txtCodigo.Text);
                
                conexao.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
                MessageBox.Show("Cliente excluído com sucesso!");
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=localhost;Database=cadClientebd;Uid=root;Pwd=KatiaJT38;");

                strSQL = "SELECT * FROM CLIENTE WHERE CODIGO = @CODIGO";

                comando = new MySqlCommand(strSQL, conexao);
                comando.Parameters.AddWithValue("@CODIGO", txtCodigo.Text);

                conexao.Open();

                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    txtNome.Text = Convert.ToString(dr["nome"]);
                    mskCpf.Text = Convert.ToString(dr["cpf"]);
                    mskCep.Text = Convert.ToString(dr["cep"]);
                    txtEndereco.Text = Convert.ToString(dr["endereco"]);
                    txtNumero.Text = Convert.ToString(dr["numero"]);
                    txtComplemento.Text = Convert.ToString(dr["complemento"]);
                    mskTelefone.Text = Convert.ToString(dr["telefone"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
                MessageBox.Show("Os dados do cliente " + txtCodigo.Text + " apresentado com sucesso!");
            }
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=localhost;Database=cadClientebd;Uid=root;Pwd=KatiaJT38;");

                strSQL = "SELECT * FROM CLIENTE";

                da = new MySqlDataAdapter(strSQL, conexao);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvDados.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
                MessageBox.Show("Os dados de todos os clientes apresentados com sucesso!");
            }
        }
                
    }
}
