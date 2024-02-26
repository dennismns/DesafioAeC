using DesafioAec.Domain.Interfaces;
using Desafio.Models;
using System.Net.Http;
using System.Net.Http.Handlers;

using System;
using System.Windows;
using System.Net.Http.Headers;
using System.Linq;
using DesafioAec.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Desafio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        HttpClient client = new HttpClient();
        List<DesafioAec.Models.CursoDTO> cursosEncontrados = new List<DesafioAec.Models.CursoDTO>();
        public MainWindow()
        {
            InitializeComponent();
            btnCadastrar.IsEnabled = false;
           
            TxtTitulo.IsReadOnly = true;
            TxtDescricso.IsReadOnly = true;
            TxtCargaHoraria.IsReadOnly = true;
            TxtNomeProfessor.IsReadOnly = true;
            txtTotal.IsReadOnly = true;
            client.BaseAddress = new Uri("http://localhost:12077/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));
        }



        private async void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
           var textoBusca = txtCurso.Text;
            
            NavegacaoSelenium n = new NavegacaoSelenium();
             cursosEncontrados = n.BuscarCurso(textoBusca);
             txtTotal.Text= cursosEncontrados.Count.ToString();
            if (cursosEncontrados.Any())
                btnCadastrar.IsEnabled = true;
                TxtTitulo.Text= cursosEncontrados[0].Titulo.ToString();
                TxtDescricso.Text= cursosEncontrados[0].Descricao.ToString();
                TxtCargaHoraria.Text= cursosEncontrados[0].CargaHoraria.ToString();
                TxtNomeProfessor.Text = cursosEncontrados[0].NomeProfessor.ToString();

           //client.BaseAddress = new Uri("http://localhost:12077");


        }

        private async void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var curso = new Curso()
                {
                    Titulo = TxtTitulo.Text,
                    Descricao = TxtDescricso.Text,
                    NomeProfessor = TxtNomeProfessor.Text,
                    CargaHoraria = TxtCargaHoraria.Text,


                };


               
                var response = await client.PostAsJsonAsync("Curso/v1/Cadastrar/", curso);
                response.EnsureSuccessStatusCode();
                MessageBox.Show("Curso cadastradado com sucesso", "Result", MessageBoxButton.OK);

            }
            catch (Exception)
            {

                MessageBox.Show("Erro ao cadstrar curso");
            }

        }
    }
}
