using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System.Net;

namespace InsUpdDel
{
    public partial class FrmUID : Form
    {
        SqlConnection conn;

        public class Author
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Author(int id, string name)
            {
                Id = id;
                Name = name;
            }
            public Author(string name)
            {
                Id = -1;
                Name = name;
            }


        }
        public void InsertAuthor(Author author)
        {
            string sqlQuery = @"INSERT INTO AuthorNames (FullName)
                        VALUES (@parName);
                        SELECT CAST(SCOPE_IDENTITY() AS INT)";
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                SqlParameter parName = new SqlParameter("@parName", author.Name);
                
                cmd.Parameters.Add(parName);
                int id = (int)cmd.ExecuteScalar();
                author.Id = id;                
                Console.WriteLine($"Запись добавлена в БД, Id: {id}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        public void UpdateAuthor(Author author)
        {
            string sqlQuery = @"UPDATE AuthorNames
                SET FullName = @parName
                WHERE Id = @parId";

            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                SqlParameter parId = new SqlParameter("@parId", author.Id);
                SqlParameter parName = new SqlParameter("@parTOName", author.Name);
                
                cmd.Parameters.Add(parId);
                cmd.Parameters.Add(parName);
                cmd.ExecuteNonQuery();
                
                Console.WriteLine($"Запись обновлена в БД");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        public void DeleteAuthor(Author author)
        {
            try
            {
                string sqlQuery = @"DELETE FROM AuthorNames
                                WHERE Id = @parId";

                

                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                cmd.Parameters.AddWithValue("@parId", author.Id);
                cmd.ExecuteNonQuery();
                
                Console.WriteLine($"Запись удалена из БД");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        Author selectedAuthor;
        List<Author> authors;

        public FrmUID()
        {
            InitializeComponent();
        }
        private void tvMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvMain.SelectedNode == null)
                return;

            selectedAuthor = authors.FirstOrDefault(t => t.Id == (int)tvMain.SelectedNode.Tag);

            tbAuthorName.Text = selectedAuthor.Name;

        }

        private void FrmUID_Load(object sender, EventArgs e)
        {
            string connStr = @"Data Source=DESKTOP-ET8RJ3S;Initial Catalog=Authors;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;";
            conn = new SqlConnection(connStr);
            authors = new List<Author>();
            GetInfo();
            FillTvMain();
        }

        private void GetInfo()
        {
            string getSqlInfo = @"SELECT * FROM AuthorNames";
            List<string> mSqlOutput = new List<string> { "Id", "FullName" };

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(getSqlInfo, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Author author = new Author((int)reader["Id"], reader["FullName"].ToString());
                    authors.Add(author);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }




        private void FillTvMain()
        {
            tvMain.Nodes.Clear();
            foreach (var author in authors)
            {
                TreeNode node = new TreeNode(author.Name);
                node.Tag = author.Id;
                tvMain.Nodes.Add(node);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Author author = new Author(tbAuthorName.Text);
            InsertAuthor(author);
            authors.Add(author);
            FillTvMain();
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (selectedAuthor == null)
                return;
            selectedAuthor.Name = tbAuthorName.Text;
            UpdateAuthor(selectedAuthor);
            FillTvMain();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (selectedAuthor == null)
                return;

            DeleteAuthor(selectedAuthor);
            tbAuthorName.Text = "";
            authors.Remove(selectedAuthor);
            FillTvMain();
        }
    }


}
