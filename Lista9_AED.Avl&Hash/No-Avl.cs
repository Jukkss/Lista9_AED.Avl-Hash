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
        private int elemento;
        private No esq;
        private No dir;
        private int nivel;

        public No(int elemento, No esq, No dir, int nivel)
        {
            this.elemento = elemento;
            this.esq = esq;
            this.dir = dir;
            this.nivel = nivel;
        }

        public No(int elemento)
        {
            this.elemento = elemento;
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
    }

    internal class Avl
    {
        private No raiz;

        public Avl()
        {
            raiz = null;
        }

        public bool Pesquisar(int x)
        {
            return Pesquisar(x, raiz);
        }

        private bool Pesquisar(int x, No i)
        {
            if (i == null)
                return false;
            else if (x == i.Elemento)
                return true;
            else if (x < i.Elemento)
                return Pesquisar(x, i.Esq);
            else
                return Pesquisar(x, i.Dir);
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
                Console.Write(i.Elemento + " ");
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
                Console.Write(i.Elemento + "(fator " + (No.GetNivel(i.Dir) - No.GetNivel(i.Esq)) + ") ");
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
                Console.Write(i.Elemento + " ");
            }
        }

        public void Inserir(int x)
        {
            raiz = Inserir(x, raiz);
        }

        private No Inserir(int x, No i)
        {
            if (i == null)
            {
                i = new No(x);
            }
            else if (x < i.Elemento)
            {
                i.Esq = Inserir(x, i.Esq);
            }
            else if (x > i.Elemento)
            {
                i.Dir = Inserir(x, i.Dir);
            }
            else
            {
                throw new Exception("Erro ao inserir! Elemento duplicado: " + x);
            }
            return Balancear(i);
        }

        public void Remover(int x)
        {
            raiz = Remover(x, raiz);
        }

        private No Remover(int x, No i)
        {
            if (i == null)
            {
                throw new Exception("Erro ao remover! Elemento não encontrado: " + x);
            }
            else if (x < i.Elemento)
            {
                i.Esq = Remover(x, i.Esq);
            }
            else if (x > i.Elemento)
            {
                i.Dir = Remover(x, i.Dir);
            }
            else if (i.Dir == null)
            {
                i = i.Esq;
            }
            else if (i.Esq == null)
            {
                i = i.Dir;
            }
            else
            {
                i.Esq = MaiorEsq(i, i.Esq);
            }
            return Balancear(i);
        }

        private No MaiorEsq(No i, No j)
        {
            if (j.Dir == null)
            {
                i.Elemento = j.Elemento;
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
                        "Erro no No(" + no.Elemento + ") com fator de balanceamento (" +
                        fator + ") inválido!");
                }
            }
            return no;
        }

        private No RotacionarDir(No no)
        {
            Console.WriteLine("Rotacionar DIR(" + no.Elemento + ")");
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
            Console.WriteLine("Rotacionar ESQ(" + no.Elemento + ")");
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

