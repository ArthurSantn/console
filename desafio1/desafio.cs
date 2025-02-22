//Empregado.cs
public DataTable Pesquisar()
{
 StringBuilder stringSql = new StringBuilder();
stringSql.Append("select Matricula, CPF, Nome, Endereco ");
stringSql.Append("from empregado ");
stringSql.Append("where 1");
if (Matricula != 0)
stringSql.Append(" and matricula=@matricula");
if (!Cpf.Equals(""))
stringSql.Append(" and cpf=@cpf");
if (!Nome.Equals(""))
stringSql.Append(" and nome like @nome");
MySqlConnection conexao=new MySqlConnection(stringConexao);
MySqlCommand comando=new MySqlCommand(stringSql.ToString(), conexao);
comando.Parameters.AddWithValue("@matricula", Matricula);
comando.Parameters.AddWithValue("@cpf", Cpf);
comando.Parameters.AddWithValue("@nome", "%"+Nome+"%");
MySqlDataAdapter adaptador = new MySqlDataAdapter();
adaptador.SelectCommand = comando;
DataTable dados = new DataTable();
adaptador.Fill(dados);
return dados;
}
//FormLocal.cs
private void Pesquisar()
{
int matricula = 0;
bool n = Int32.TryParse(textMatricula.Text, out matricula);
Empregado empregado = new Empregado();
empregado.Matricula = matricula;
empregado.Cpf = textCpf.Text;
empregado.Nome = textNome.Text;
dataGridViewEmpregado.DataSource = empregado.Pesquisar();
}