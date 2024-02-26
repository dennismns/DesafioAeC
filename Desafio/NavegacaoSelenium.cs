
using DesafioAec.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Desafio
{
    public class NavegacaoSelenium
    {


        public List<CursoDTO> BuscarCurso(string texto)
        {
            try
            {

            
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://www.alura.com.br");

                //driver.Manage().Window.Maximize();
                IWebElement element = driver.FindElement(By.XPath("//*[@id=\"header-barraBusca-form-campoBusca\"]"));
                element.SendKeys(texto);
                IWebElement clik = driver.FindElement(By.XPath("/html/body/main/section[1]/header/div/nav/div[2]/form/button"));
                clik.Click();

                Thread.Sleep(2000);
                var curso2 = driver.FindElements(By.XPath("//*[@id='busca-resultados']/ul/li/a[div[contains(h4/text(), '"+texto+"')]]"));

                List<CursoDTO> cursos = new List<CursoDTO>();
                foreach (var ele in curso2)
                {
                    CursoDTO c = new CursoDTO();
                           
                   c.Titulo = ele.FindElement(By.XPath("./div/h4")).Text;
                   c.Descricao = ele.FindElement(By.XPath("./div/p")).Text;
               
                   var href = ele.GetAttribute("href"); 
                    driver.Navigate().GoToUrl(href);
                    Thread.Sleep(2000);
                    c.CargaHoraria = driver.FindElement(By.XPath("/html/body/section[1]/div/div[2]/div[1]/div/div[1]/div/p[1]")).Text;
                    c.NomeProfessor = driver.FindElement(By.XPath("//*[@id=\"section-icon\"]/div[1]/section/div/div/div/h3")).Text;

                    cursos.Add(c);
                    driver.Navigate().Back();

                }
                driver.Quit();

                return cursos;
                }
                catch (NoSuchElementException)
                {
            
                    MessageBox.Show("O elemento não existe");
                    return null;
                }
            }
        }
    }

