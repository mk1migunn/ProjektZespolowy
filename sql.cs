using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading;

namespace sql_test
{ 
    class Program
    {
        static void wypisz (SqlConnection pol){
            SqlCommand komendaSQL = pol.CreateCommand();
            komendaSQL.CommandText = "SELECT * FROM Gra_01";
            SqlDataReader czytnik = komendaSQL.ExecuteReader();
            Console.WriteLine("Wiersze tabeli:");


            while (czytnik.Read()) {
                Console.WriteLine(czytnik["id_gracza"] + " " + czytnik["nazwa"] + " " + czytnik["hajs"]);
            }
            czytnik.Close();
           // komendaSQL.Cancel();
        }
        static void pobierz_plansze(List<Pola> plansza, SqlConnection pol){
            SqlCommand komendaSQL = pol.CreateCommand();
            komendaSQL.CommandText = "SELECT * FROM Pola";
            SqlDataReader czytnik = komendaSQL.ExecuteReader();
            Pola temp=new Pola();
            while (czytnik.Read()){

                //  temp.edit(czytnik["nazwa"].ToString(),czytnik["ilosc_domkow"],czytnik["koszt_uslugi"],czytnik["koszt_zakupu"],czytnik["koszt_domkow"],czytnik["mnoznik"],czytnik["wlasciciel"]);
                  temp.edit(czytnik["nazwa"].ToString(),czytnik.GetInt16(0), czytnik.GetInt16(0), czytnik.GetInt16(0), czytnik.GetInt16(0), czytnik.GetInt16(0), czytnik.GetInt16(0));
                temp.wypisz();
            }
        }

        static int oczekanko(SqlConnection pol)
        {
            int a = 123;
            SqlCommand komenda = pol.CreateCommand();
             komenda.CommandText = "select tura_gracza from Gra_01 where id_gracza=1;";
            while (a != 1){
                SqlDataReader czytnik = komenda.ExecuteReader();
                czytnik.Read();
                a = czytnik.GetInt16(0);
                Console.WriteLine(a);
                czytnik.Close();
                Thread.Sleep(5000);
            }
            
            if (a == 1)
                Console.WriteLine(a);
            else
                Console.WriteLine("no patrz nie udalo sie");
            return 0;
        }
        static void Main(string[] args)
        {
            List<Pola> plansza =new List<Pola>();
       
  
            try
            {// dane do połaczenia z baza danych
                SqlConnection polaczenie = new SqlConnection("Server=projektasd.database.windows.net;DATABASE=monopol;User ID=master;Password=Krowa123!;");
                polaczenie.Open();
                //ta funkcja jeszcze nie działa 
               // pobierz_plansze(plansza, polaczenie);
      
                wypisz(polaczenie);

                //funkcja sprawdzajaca ture 
                oczekanko(polaczenie);
                polaczenie.Close();

            Console.ReadKey();
        }
            catch (SqlException e)
            {
                Console.WriteLine("Wystąpił nieoczekiwany błąd!");
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
