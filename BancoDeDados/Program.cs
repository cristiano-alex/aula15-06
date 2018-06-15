using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados
{
    class Program
    {
        static void Main(string[] args)
        {
            BancoDeDados.ModelFutebolContainer ctx
             = new ModelFutebolContainer();


            Time Flamengo;
            Flamengo = (from time in ctx.TimeSet
                       where time.Nome == "Flamengo"
                       select time).SingleOrDefault();
            if (Flamengo == null)
            {
                Flamengo = new BancoDeDados.Time();
                Flamengo.Nome = "Flamengo";
                Flamengo.Fundacao = new DateTime(1895, 11, 15);
                ctx.TimeSet.Add(Flamengo);
                ctx.SaveChanges();
            }

            if (Flamengo.Jogadores.Count == 0)
            {

                Jogador Paqueta = new Jogador();
                Paqueta.Nome = "Paqueta";
                Paqueta.NumeroDaCamisa = 12;
                Paqueta.DataNascimento = new DateTime(1990, 02, 28);

                Flamengo.Jogadores.Add(Paqueta);

                Jogador VJunior = new Jogador();
                VJunior.Nome = "Vinicius Junior";
                VJunior.NumeroDaCamisa = 12;
                VJunior.DataNascimento = 
                    new DateTime(1999, 02, 28);

                Flamengo.Jogadores.Add(VJunior);
            }

            Time Coritiba;
            Coritiba = (from time in ctx.TimeSet
                        where time.Nome == "Coritiba"
                        select time).SingleOrDefault();
            if (Coritiba == null)
            {
                Coritiba = new BancoDeDados.Time();
                Coritiba.Nome = "Coritiba";
                Coritiba.Fundacao = new DateTime(1895, 11, 15);
                ctx.TimeSet.Add(Coritiba);
                ctx.SaveChanges();
            }

            Jogador jogador = (from j in ctx.JogadorSet
                               where j.Nome == "Paqueta"
                               && j.NumeroDaCamisa == 12
                               select j).SingleOrDefault();

            if (jogador != null)
            {
                //Jogador j = ctx.JogadorSet.Find(1);
                jogador.Nome = "Paquetá";

                ListarJogadores(Flamengo);

                ctx.JogadorSet.Remove(jogador);
                ctx.SaveChanges();

            }

            ListarJogadores(Flamengo);

            PesquisarJogador();
            Console.WriteLine("Ok!");
            Console.ReadKey();

        }

        public static void PesquisarJogador()
        {
            Console.WriteLine("Digite um termo para pesquisar jogadores");
            String termo = Console.ReadLine();
            BancoDeDados.ModelFutebolContainer ctx
             = new ModelFutebolContainer();
            var jogadores = from j in ctx.JogadorSet
                            where j.Nome.ToLower().Contains(termo.ToLower())
                            select j;
            foreach(Jogador j in jogadores)
            {
                Console.WriteLine( "Nome do Jogador:" + j.Nome);
                Console.WriteLine("Time do Jogador:" + j.Time.Nome);
            }
        }


        public static void ListarJogadores(Time time)
        {
            Console.WriteLine("************" );
            Console.WriteLine("Time: " + time.Nome);
            Console.WriteLine("===Jogadores===");
            foreach (Jogador j in time.Jogadores)
            {
                Console.WriteLine("Nome: " + j.Nome);
                Console.WriteLine("Data de Nascimento: " + j.DataNascimento);
                Console.WriteLine("Número da Camisa" + j.NumeroDaCamisa);
            }
        }
    }

   
}
