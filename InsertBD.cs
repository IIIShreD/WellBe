using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class InsertBD
    {
        DB db = new DB();
        public void P(ToolStripTextBox topic, ToolStripTextBox weight, DateTimePicker BreakfastT, DateTimePicker BreakfastL, DateTimePicker BreakfastD, TextBox topicT, TextBox topicL, TextBox topicD, TextBox WeightT, TextBox WeightL, TextBox WeightD, TextBox CalorieD, TextBox CalorieT, TextBox CalorieL, TextBox Author)
        {

            string query = $"insert into Дневник(ТемаДневника,ВашВес,ВремяПриемаЗавтрак,ВремяПриемаОбед,ВремяПриемаУжин,НаименованиеПродуктовЗавтрак,НаименованиеПродуктовОбед,НаименованиеПродуктовУжин,ВесПищиЗавтрак,ВесПищиОбед,ВесПищиУжин,КалорийностьЗавтрак,КалорийностьОбед,КалорийностьУжин,Автор) values ('{topic.Text}','{weight.Text}','{BreakfastT.Text}','{BreakfastL.Text}','{BreakfastD.Text}','{topicT.Text}','{topicL.Text}','{topicD.Text}','{WeightT.Text}','{WeightL.Text}','{WeightD.Text}','{CalorieD.Text}','{CalorieT.Text}','{CalorieL.Text}','{Author.Text}')";
            SqlCommand command = new SqlCommand(query, db.con);
            try
            {
                db.con.Open();
                int rowsAffected = command.ExecuteNonQuery();
                MessageBox.Show("Ваш дневник сохранен!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }

        }

        public void PR(ComboBox comboBox, TextBox textBox)
        {
            string sqlQuery = $"SELECT * FROM Дневник where Автор='{textBox.Text}'";

            try
            {
                db.con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, db.con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        comboBox.Items.Add(reader["id"].ToString());
                    }
                }
                reader.Close();
                db.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        public void PS(ComboBox comboBox,ToolStripTextBox topic, ToolStripTextBox weight, DateTimePicker BreakfastT, DateTimePicker BreakfastL, DateTimePicker BreakfastD, TextBox topicT, TextBox topicL, TextBox topicD, TextBox WeightT, TextBox WeightL, TextBox WeightD, TextBox CalorieD, TextBox CalorieT, TextBox CalorieL, TextBox Author)
        {
            string sqlQuery = $"SELECT * FROM Дневник where Автор='{Author.Text}' and id = '{comboBox.Text}'";

            try
            {
                db.con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, db.con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        topic.Text = reader["ТемаДневника"].ToString();
                        weight.Text = reader["ВашВес"].ToString();
                        BreakfastT.Text = reader["ВремяПриемаЗавтрак"].ToString();
                        BreakfastL.Text = reader["ВремяПриемаОбед"].ToString();
                        BreakfastD.Text = reader["ВремяПриемаУжин"].ToString();
                        topicT.Text = reader["НаименованиеПродуктовЗавтрак"].ToString();
                        topicL.Text = reader["НаименованиеПродуктовОбед"].ToString();
                        topicD.Text = reader["НаименованиеПродуктовУжин"].ToString();
                        WeightT.Text = reader["ВесПищиЗавтрак"].ToString();
                        WeightL.Text = reader["ВесПищиОбед"].ToString();
                        WeightD.Text = reader["ВесПищиУжин"].ToString();
                        CalorieD.Text = reader["КалорийностьЗавтрак"].ToString();
                        CalorieT.Text = reader["КалорийностьОбед"].ToString();
                        CalorieL.Text = reader["КалорийностьУжин"].ToString();
                        Author.Text = reader["Автор"].ToString();

                    }
                }
                reader.Close();
                db.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        public void SearchAll(ListBox listBox, TextBox textBox)
        {
            db.con.Open();

            using (var command = db.con.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Дневник where ТемаДневника LIKE '%{textBox.Text}%'";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox.Items.Add($"Тема дневника: {reader["ТемаДневника"].ToString()}"
                + $" | Завтрак {reader["ВремяПриемаЗавтрак"].ToString()} - {reader["НаименованиеПродуктовЗавтрак"].ToString()}: Вес пищи {reader["ВесПищиЗавтрак"].ToString()} г., Калорийность {reader["КалорийностьЗавтрак"].ToString()} ккал"
                + $" | Обед {reader["ВремяПриемаОбед"].ToString()} - {reader["НаименованиеПродуктовОбед"].ToString()}: Вес пищи {reader["ВесПищиОбед"].ToString()} г., Калорийность {reader["КалорийностьОбед"].ToString()} ккал"
                + $" | Ужин {reader["ВремяПриемаУжин"].ToString()} - {reader["НаименованиеПродуктовУжин"].ToString()}: Вес пищи {reader["ВесПищиУжин"].ToString()} г., Калорийность {reader["КалорийностьУжин"].ToString()} ккал");
                    }
                }
            }
            db.con.Close();
        }

        public void LoadL(ListBox listBox)
        {
            db.con.Open();

            using (var command = db.con.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM Дневник";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox.Items.Add($"{reader["id"].ToString()} | Тема дневника: {reader["ТемаДневника"].ToString()}"
                + $" | Завтрак {reader["ВремяПриемаЗавтрак"].ToString()} - {reader["НаименованиеПродуктовЗавтрак"].ToString()}: Вес пищи {reader["ВесПищиЗавтрак"].ToString()} г., Калорийность {reader["КалорийностьЗавтрак"].ToString()} ккал"
                + $" | Обед {reader["ВремяПриемаОбед"].ToString()} - {reader["НаименованиеПродуктовОбед"].ToString()}: Вес пищи {reader["ВесПищиОбед"].ToString()} г., Калорийность {reader["КалорийностьОбед"].ToString()} ккал"
                + $" | Ужин {reader["ВремяПриемаУжин"].ToString()} - {reader["НаименованиеПродуктовУжин"].ToString()}: Вес пищи {reader["ВесПищиУжин"].ToString()} г., Калорийность {reader["КалорийностьУжин"].ToString()} ккал");
                    }
                }
            }
            db.con.Close();
        }


        public void SearchTopic(TextBox comboBox, ToolStripTextBox topic, ToolStripTextBox weight, DateTimePicker BreakfastT, DateTimePicker BreakfastL, DateTimePicker BreakfastD, TextBox topicT, TextBox topicL, TextBox topicD, TextBox WeightT, TextBox WeightL, TextBox WeightD, TextBox CalorieD, TextBox CalorieT, TextBox CalorieL, TextBox Author)
        {
            string sqlQuery = $"SELECT * FROM Дневник where id = '{comboBox.Text}'";

            try
            {
                db.con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, db.con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        topic.Text = reader["ТемаДневника"].ToString();
                        weight.Text = reader["ВашВес"].ToString();
                        BreakfastT.Text = reader["ВремяПриемаЗавтрак"].ToString();
                        BreakfastL.Text = reader["ВремяПриемаОбед"].ToString();
                        BreakfastD.Text = reader["ВремяПриемаУжин"].ToString();
                        topicT.Text = reader["НаименованиеПродуктовЗавтрак"].ToString();
                        topicL.Text = reader["НаименованиеПродуктовОбед"].ToString();
                        topicD.Text = reader["НаименованиеПродуктовУжин"].ToString();
                        WeightT.Text = reader["ВесПищиЗавтрак"].ToString();
                        WeightL.Text = reader["ВесПищиОбед"].ToString();
                        WeightD.Text = reader["ВесПищиУжин"].ToString();
                        CalorieD.Text = reader["КалорийностьЗавтрак"].ToString();
                        CalorieT.Text = reader["КалорийностьОбед"].ToString();
                        CalorieL.Text = reader["КалорийностьУжин"].ToString();
                    }
                }
                reader.Close();
                db.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
