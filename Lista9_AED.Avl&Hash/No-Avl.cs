using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace Lista9_AED.Avl_Hash
{
    internal class No
    {
        private Paciente paciente;
        private int elemento;
        private No esq;
        private No dir;
        private int nivel;

        public No(Paciente paciente, No esq, No dir, int nivel)
        {
            this.paciente = paciente;
            this.esq = esq;
            this.dir = dir;
            this.nivel = nivel;
        }

        public No(Paciente paciente)
        {
            this.paciente = paciente;
            this.esq = null;
            this.dir = null;
            this.nivel = 1;
        }

        public static int GetNivel(No no)
        {
            return (no == null) ? 0 : no.nivel;
        }

        public void SetNivel()
        {
            this.nivel = 1 + Math.Max(GetNivel(esq), GetNivel(dir));
        }

        public int Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }

        public No Esq
        {
            get { return esq; }
            set { esq = value; }
        }

        public No Dir
        {
            get { return dir; }
            set { dir = value; }
        }
        public Paciente Paciente
        {
            get { return paciente; }
            set { paciente = value; }
        }
    }

    internal class Avl
    {
        private No raiz;

        public Avl()
        {
            raiz = null;
        }

        public Paciente Pesquisar(long cpf)
        {
            return Pesquisar(cpf, raiz);
        }

        private Paciente Pesquisar(long cpf, No i)
        {
            if (i == null)
                return null;
            else if (cpf == i.Paciente.Cpf)
                return i.Paciente;
            else if (cpf < i.Paciente.Cpf)
                return Pesquisar(cpf, i.Esq);
            else
                return Pesquisar(cpf, i.Dir);
        }

        public void CaminharCentral()
        {
            CaminharCentral(raiz);
        }

        private void CaminharCentral(No i)
        {
            if (i != null)
            {
                CaminharCentral(i.Esq);
                Console.WriteLine(i.Paciente.Nome);
                CaminharCentral(i.Dir);
            }
        }

        public void CaminharPre()
        {
            CaminharPre(raiz);
        }

        private void CaminharPre(No i)
        {
            if (i != null)
            {
                Console.WriteLine(i.Paciente.Email);
                CaminharPre(i.Esq);
                CaminharPre(i.Dir);
            }
        }

        public void CaminharPos()
        {
            CaminharPos(raiz);
        }

        private void CaminharPos(No i)
        {
            if (i != null)
            {
                CaminharPos(i.Esq);
                CaminharPos(i.Dir);
                Console.WriteLine(i.Paciente.Cpf);
            }
        }

        public void Inserir(Paciente paciente)
        {
            raiz = Inserir(paciente, raiz);
        }

        private No Inserir(Paciente paciente, No i)
        {
            if (i == null)
            {
                i = new No(paciente);
            }
            else if (paciente.Cpf < i.Paciente.Cpf)
            {
                i.Esq = Inserir(paciente, i.Esq);
            }
            else if (paciente.Cpf > i.Paciente.Cpf)
            {
                i.Dir = Inserir(paciente, i.Dir);
            }
            else
            {
                throw new Exception("Erro ao inserir! CPF duplicado: " + paciente.Cpf);
            }
            return Balancear(i);
        }

        public void Remover(long cpf)
        {
            raiz = Remover(cpf, raiz);
        }

        private No Remover(long cpf, No i)
        {
            if (i == null)
                throw new Exception("Erro ao remover! Paciente não encontrado: " + cpf);
            else if (cpf < i.Paciente.Cpf)
                i.Esq = Remover(cpf, i.Esq);
            else if (cpf > i.Paciente.Cpf)
                i.Dir = Remover(cpf, i.Dir);
            else if (i.Dir == null)
                i = i.Esq;
            else if (i.Esq == null)
                i = i.Dir;
            else
                i.Esq = MaiorEsq(i, i.Esq);

            return Balancear(i);
        }

        private No MaiorEsq(No i, No j)
        {
            if (j.Dir == null)
            {
                i.Paciente = j.Paciente;
                j = j.Esq;
            }
            else
            {
                j.Dir = MaiorEsq(i, j.Dir);
            }
            return Balancear(j);
        }

        private No Balancear(No no)
        {
            if (no != null)
            {
                int fator = No.GetNivel(no.Dir) - No.GetNivel(no.Esq);

                if (fator >= -1 && fator <= 1)
                {
                    no.SetNivel();
                }
                else if (fator == 2)
                {
                    int fatorFilhoDir = No.GetNivel(no.Dir.Dir) - No.GetNivel(no.Dir.Esq);
                    if (fatorFilhoDir < 0)
                    {
                        no.Dir = RotacionarDir(no.Dir);
                    }
                    no = RotacionarEsq(no);
                }
                else if (fator == -2)
                {
                    int fatorFilhoEsq = No.GetNivel(no.Esq.Dir) - No.GetNivel(no.Esq.Esq);
                    if (fatorFilhoEsq > 0)
                    {
                        no.Esq = RotacionarEsq(no.Esq);
                    }
                    no = RotacionarDir(no);
                }
                else
                {
                    throw new Exception(
                        "Erro no nó com CPF(" + no.Paciente.Cpf + ") com fator (" +
                        fator + ") inválido!");
                }
            }
            return no;
        }

        private No RotacionarDir(No no)
        {
            Console.WriteLine("Rotacionar DIR(" + no.Paciente.Cpf + ")");
            No noEsq = no.Esq;
            No noEsqDir = noEsq.Dir;

            noEsq.Dir = no;
            no.Esq = noEsqDir;

            no.SetNivel();
            noEsq.SetNivel();

            return noEsq;
        }

        private No RotacionarEsq(No no)
        {
            Console.WriteLine("Rotacionar ESQ(" + no.Paciente.Cpf + ")");
            No noDir = no.Dir;
            No noDirEsq = noDir.Esq;

            noDir.Esq = no;
            no.Dir = noDirEsq;

            no.SetNivel();
            noDir.SetNivel();

            return noDir;
        }
    }
}

