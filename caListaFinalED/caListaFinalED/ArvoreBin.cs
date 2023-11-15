using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caListaFinalED
{
    internal class ArvoreBin
    {
        // atributos 
        private NohArvore root;

        // métodos
        public ArvoreBin()
        {
            root = null;
        }

        public bool isEmpty()
        {
            if (root == null)
                return true;
            else
                return false;
        }

        public void inserir(int n) // aridade 1
        {
            inserir(this.root, n); // aridade 2
        }

        public void inserir(NohArvore node, int valor) // aridade 2
        {                               // 10 e 15
            if (this.root == null)
            {
                this.root = new NohArvore(valor);
            }
            else
            {
                if (valor < node.getValor())
                { // insere a esquerda
                    if (node.getNoEsquerda() != null)
                    {
                        inserir(node.getNoEsquerda(), valor);
                    }
                    else // subarvore da esquerda está vazia
                    {
                        //Se nodo esquerdo vazio insere o novo no aqui 
                        node.setNoEsquerda(new NohArvore(valor));
                    }

                    //Verifica se o valor a ser inserido é maior que o noh corrente 
                    //da árrvore, se sim vai para subarvore direita 
                }
                else if (valor > node.getValor())
                {
                    //Se tiver elemento no no direito continua a busca 
                    if (node.getNoDireita() != null)
                    {
                        inserir(node.getNoDireita(), valor);
                    }
                    else // subárvore da direita está vazia
                    {
                        //Se nodo direito vazio insere o novo no aqui 
                        node.setNoDireita(new NohArvore(valor));
                    }
                } // fim do if para inserir a direita
            }

        } // fim do metodo inserir - aridade 2

        public void imprimirArvore()
        {
            if (this.root == null)
                Console.WriteLine("Árvore vazia");
            else
                imprimirArvore(this.root);
        }

        public void imprimirArvore(NohArvore node)
        {
            if (node.getNoEsquerda() != null)
            {
                imprimirArvore(node.getNoEsquerda());
            }

            Console.WriteLine("Noh: " + node.getValor());

            if (node.getNoDireita() != null)
            {
                imprimirArvore(node.getNoDireita());
            }

        }

        //remove um nó(já encontrado)
        protected int removeNoh(NohArvore noh)
        {
            if (noh.NoEsquerda == null && noh.NoDireita == null)
            {
                int save = noh.Valor;
                NohArvore previo = encontraPrevio(noh);
                if (noh == previo.NoDireita)
                    previo.NoDireita = null;
                else
                    previo.NoEsquerda = null;


                return save;
            }
            else if (noh.NoDireita == null)
            {
                //se não existe esquerda, só passa a direita para ser o no
                int save = noh.Valor;
                noh.Valor = noh.NoEsquerda.Valor;
                noh.NoDireita = noh.NoEsquerda.NoDireita;
                noh.NoEsquerda = noh.NoEsquerda.NoEsquerda;

                return save;
            }
            else if (noh.NoEsquerda == null)
            {
                //o contrário do acima
                int save = noh.Valor;
                noh.Valor = noh.NoDireita.Valor;
                noh.NoEsquerda = noh.NoDireita.NoEsquerda;
                noh.NoDireita = noh.NoDireita.NoDireita;
                return save;
            }
            else
            {
                //pega o maior dos valores menores q o no(o mais a direita dos da esquerda) e substitui
                int save = noh.Valor;
                NohArvore aux = noh.NoEsquerda;
                if (aux.NoDireita != null)
                {
                    while (aux.NoDireita.NoDireita != null)
                    {
                        aux = aux.NoDireita;
                    }

                    NohArvore novoPrincipal = aux.NoDireita;
                    aux.NoDireita = aux.NoDireita.NoEsquerda;
                    noh.Valor = novoPrincipal.Valor;
                }
                else
                {
                    noh.Valor = noh.NoEsquerda.Valor;
                    noh.NoEsquerda = noh.NoEsquerda.NoEsquerda;
                }
                //salva quem vai ser o novo principal, ajeita a parte de baixo da arvore e troca o valor do inicial
                
                return save;
            }
        }

        //supõe que o valor existe
        public NohArvore encontraNoh(int valor)
        {
            if (this.root.Valor == valor)
                return this.root;
            else if(this.root.Valor > valor)
                return encontraNoh(valor, this.root.NoEsquerda);
            else
                return encontraNoh(valor, this.root.NoDireita);
        }

        public NohArvore encontraNoh(int valor, NohArvore aux)
        {
            if (aux.Valor == valor)
                return aux;
            else if (aux.Valor > valor)
                return encontraNoh(valor, aux.NoEsquerda);
            else
                return encontraNoh(valor, aux.NoDireita);
        }

        public NohArvore encontraPrevio(NohArvore alvo)
        {
            if (this.root == alvo)
                return null;
            else if (this.root.Valor > alvo.Valor)
                return encontraPrevio(alvo, this.root.NoEsquerda);
            else
                return encontraPrevio(alvo, this.root.NoDireita);

        }

        public NohArvore encontraPrevio(NohArvore alvo, NohArvore aux)
        {
            if (alvo == aux.NoEsquerda || alvo == aux.NoDireita)
                return aux;
            else if (aux.Valor > alvo.Valor)
                return encontraPrevio(alvo, aux.NoEsquerda);
            else
                return encontraPrevio(alvo, aux.NoDireita);
        }


        //juntamos a função de encontrar qualquer no na arvore com a de remover um no especifico para remover qualquer um
        public int removeQlqrNoh(int valor)
        {
            NohArvore aux = encontraNoh(valor);
            return removeNoh(aux);
        }


        //calcula a altura de uma arvore
        public int calculaAltura()
        {
            if(this.root == null)
            {
                return -1;
            }

            return calculaAltura(this.root);
        }


        public int calculaAltura(NohArvore noh)
        {
            if (noh.NoDireita == null && noh.NoEsquerda == null)
            {
                return 0;
            }
            else
            {
                if (noh.NoDireita == null && noh.NoEsquerda != null)
                    return 1 + calculaAltura(noh.NoEsquerda);
                else if (noh.NoEsquerda == null && noh.NoDireita != null)
                    return 1 + calculaAltura(noh.NoDireita);
                else
                {
                    int altDir = calculaAltura(noh.NoDireita);
                    int altEsq = calculaAltura(noh.NoEsquerda);
                    if (altDir > altEsq)
                        return altDir + 1;
                    else
                        return altEsq + 1;
                }
            }
        }

        //conta o numero de nos de uma arvore
        public int contaNos()
        {
            if (this.root == null)
            {
                return 0;
            }

            return contaNos(this.root);
        }

        //conta o numero de nos da arvore
        public int contaNos(NohArvore noh)
        {
            if (noh.NoDireita == null && noh.NoEsquerda == null)
            {
                return 1;
            }
            else
            {
                if (noh.NoDireita == null && noh.NoEsquerda != null)
                    return 1 + contaNos(noh.NoEsquerda);
                else if (noh.NoEsquerda == null && noh.NoDireita != null)
                    return 1 + contaNos(noh.NoDireita);
                else
                {
                    return 1 + contaNos(noh.NoDireita) + contaNos(noh.NoEsquerda);
                }
            }
        }

        //conta as folhas de uma arvore
        public int contaFolhas()
        {
            if (this.root == null)
            {
                return 0;
            }

            return contaFolhas(this.root);
        }

        public int contaFolhas(NohArvore noh)
        {
            if (noh.NoDireita == null && noh.NoEsquerda == null)
            {
                return 1;
            }
            else
            {
                if (noh.NoDireita == null && noh.NoEsquerda != null)
                    return contaFolhas(noh.NoEsquerda);
                else if (noh.NoEsquerda == null && noh.NoDireita != null)
                    return contaFolhas(noh.NoDireita);
                else
                {
                    return contaFolhas(noh.NoDireita) + contaFolhas(noh.NoEsquerda);
                }
            }
        }

        //comeco das funcoes para testar igualdade de arvores

        public bool testaIgualdade(ArvoreBin arvore2)
        {
            if (this.root.Valor == arvore2.root.Valor)
            {
                return testaNoh(this.root.NoEsquerda, arvore2.root.NoEsquerda) && testaNoh(this.root.NoDireita, arvore2.root.NoDireita);
            }
            else
                return false;
        }

        public bool testaNoh(NohArvore nohDa1, NohArvore nohDa2)
        {
            if(nohDa1 == null && nohDa2 == null)
            {
                return true;
            }
            else if ((nohDa1 == null && nohDa2!= null) || (nohDa2 == null && nohDa1 != null))
            {
                return false;
            }
            else if (nohDa1.Valor == nohDa2.Valor)
            {
                return testaNoh(nohDa1.NoDireita, nohDa2.NoDireita) && testaNoh(nohDa1.NoEsquerda, nohDa2.NoEsquerda);
            }
            else
                return false;
        }

        //fim das funcoes para testar igualdade de arvores

        //inicio do calculo do fator de balanceamento
        public int fatorDeBalanceamentoDaRaiz()
        {
            return calculaAltura(this.root.NoEsquerda) - calculaAltura(this.root.NoDireita);
        }
    }
}
