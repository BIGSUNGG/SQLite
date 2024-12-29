using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

public class ChatGateWay
{
    public int Id { get; private set; }
    public DateTime DateTime { get; set; }
    public AccountGateWay Sender { get; set; }
    public string Text { get; set; }

    public bool Insert()
    {
        // DB 연결
        using (SqliteConnection connection = new SqliteConnection(ConnectionString.GetSqliteConnectionString()))
        {
            connection.Open();

            // DB 연결 실패 시 null 반환
            if (connection.State != ConnectionState.Open)
            {
                Trace.WriteLine($"Failed to connect Sql Lite Server, Connection String : {ConnectionString.GetSqliteConnectionString()}");
                return false;
            }

            // 중복되지 않는 PK 구하기
            {
                // 가장 큰 Id를 가진 채팅 데이터 구하기
                ChatGateWay biggestIdChat = SelectAll().OrderByDescending(c => c.Id).FirstOrDefault();
                Id = biggestIdChat == null ? 0 : biggestIdChat.Id + 1;
            }

            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Chat(Id, DateTime, Text, SenderId) VALUES(@Id, @DateTime, @Text, @SenderId)";
            command.Parameters.Add(new SqliteParameter("@Id", Id));
            command.Parameters.Add(new SqliteParameter("@DateTime", DateTime.ToString("yyyy-MM-dd HH:mm:ss")));
            command.Parameters.Add(new SqliteParameter("@Text", Text));
            command.Parameters.Add(new SqliteParameter("@SenderId", Sender.Id));
            command.ExecuteReader();

            connection.Close();
            return true;
        }
    }

    public static List<ChatGateWay> SelectAll()
    {
        // DB 연결
        using (SqliteConnection connection = new SqliteConnection(ConnectionString.GetSqliteConnectionString()))
        {
            connection.Open();

            // DB 연결 실패 시 null 반환
            if (connection.State != ConnectionState.Open)
            {
                Trace.WriteLine($"Failed to connect Sql Lite Server, Connection String : {ConnectionString.GetSqliteConnectionString()}");
                return null;
            }

            List<ChatGateWay> result = new List<ChatGateWay>();

            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Id, DateTime, Text, SenderId FROM Chat";
            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int index = 0;

                int id = reader.GetInt32(index++);
                DateTime dateTime = DateTime.Parse(reader.GetString(index++));
                string text = reader.GetString(index++);
                int senderId = reader.GetInt32(index++);

                ChatGateWay item = new ChatGateWay();
                item.Id = id;
                item.DateTime = dateTime;
                item.Text = text;
                item.Sender = AccountGateWay.Select(senderId);

                if (item.Sender == null)
                    Trace.WriteLine($"Account id {senderId} is not exist in db");

                result.Add(item);
            }

            reader.Close();
            connection.Close();

            return result;
        }
    }
}
