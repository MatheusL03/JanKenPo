using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp1.ViewModels
{
    public partial class JankepoViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _nome;

        [ObservableProperty]
        private Opcao _escolha;

        [ObservableProperty]
        private Jogador _jogador;

        [ObservableProperty]
        private Jogador _maquina;

        [ObservableProperty]
        private string _result;

        [ObservableProperty]
        private int _pontuacao;


        public ICommand MakeChoiceCommand { get; }


        public JankepoViewModel()
        {
            Jogador = new Jogador(Nome);
            Maquina = new Jogador("Máquina");
            MakeChoiceCommand = new Command(MakeChoice);
        }

        private void MakeChoice()
        {
            Jogador.Nome = Nome;
            Jogador.Escolha = Escolha;
            Maquina.Escolha = (Opcao)new Random().Next(0, 3);
            DetermineWinner();
            Pontuacao = Jogador.Pontuacao;
        }

        private void DetermineWinner()
        {
            if(Jogador.Escolha == Maquina.Escolha)
            {
                Jogador.Pontuacao++;
                Maquina.Pontuacao++;
                Result = "Empate!";
            }
            else if((Jogador.Escolha == Opcao.PEDRA && Maquina.Escolha == Opcao.TESOURA) ||
                    (Jogador.Escolha == Opcao.PAPEL && Maquina.Escolha == Opcao.PEDRA) ||
                    (Jogador.Escolha == Opcao.TESOURA && Maquina.Escolha == Opcao.PAPEL))
            {
                Jogador.Pontuacao += 3;
                Result = $"{Jogador.Nome} Venceu";
            }
            else
            {
                Maquina.Pontuacao++;
                Result = $"{Maquina.Nome}Venceu!"; 
            }

        }

    }
}
