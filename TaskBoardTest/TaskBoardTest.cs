using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TaskBoard.Controllers;
using System.Web.Mvc;
using TaskBoard.Models.Classes;
using OpenQA.Selenium.Support.UI;
using TaskBoardML.Model;

namespace TaskBoardTest
{
    [TestClass]
    public class TaskBoardTest
    {

        [TestMethod]
        public void CanIstantiateTaskBoard()
        {
            HomeBoardController homeBoardController = new HomeBoardController();
        }

        [TestMethod]
        public void TaskBoard()
        {
            HomeBoardController homeBoardController = new HomeBoardController();
            ViewResult result = homeBoardController.TaskBoard() as ViewResult;
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void AddCustomerCard()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:44355/HomeBoard/TaskBoard");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.FindElement(By.Id("addCustomerCard")).Click();
            driver.FindElement(By.Name("ProjeNo")).SendKeys("Hastane");
            driver.FindElement(By.Name("DolduranMusteri")).SendKeys("Rafet");
            driver.FindElement(By.Name("Tarih")).SendKeys("18.10.2020");
            driver.Quit();
        }

        public TestContext TestContext { get; set; }
        [TestMethod]
        [DataSource("System.Data.SqlClient", "Data Source=.; Initial Catalog=ScrumTaskBoardDb; Integrated Security=TRUE", "MüsteriKart", DataAccessMethod.Sequential)]

        public void DataDrivenCustomerCardTest()
        {
            MüsteriKart müsteriKart = new MüsteriKart();
            müsteriKart.ProjeNo = TestContext.DataRow["ProjeNo"].ToString();
            müsteriKart.KartNo = TestContext.DataRow["KartNo"].ToString();
            Assert.IsNotNull(müsteriKart.ProjeNo);
            Assert.IsNotNull(müsteriKart.KartNo);
        }

        [TestMethod]
        [DataSource("System.Data.SqlClient", "Data Source=.; Initial Catalog=ScrumTaskBoardDb; Integrated Security=TRUE", "TeknikKarts", DataAccessMethod.Sequential)]
        public void DataDrivenTechnicalCardTest()
        {
            TeknikKart teknikKart = new TeknikKart();
            teknikKart.TeknikUzman = TestContext.DataRow["TeknikUzman"].ToString();
            teknikKart.Tarih = TestContext.DataRow["Tarih"].ToString();
            Assert.IsNotNull(teknikKart.TeknikUzman);
            Assert.IsNotNull(teknikKart.Tarih);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"|DataDirectory|\Data\TaskBoardWork.csv",
            "TaskBoardWork#csv",DataAccessMethod.Sequential)]
        public void RegressionData()
        {
            MüsteriKart müsteriKart = new MüsteriKart();
            TeknikKart teknikKart = new TeknikKart();
            müsteriKart.Risk = TestContext.DataRow["Risk"].ToString();
            müsteriKart.Oncelik = TestContext.DataRow["Oncelik"].ToString();
            müsteriKart.IslemTipi = TestContext.DataRow["IslemTipi"].ToString();
            teknikKart.TeknikUzman = TestContext.DataRow["TeknikUzman"].ToString();
            Assert.IsNotNull(müsteriKart.Risk);
            Assert.IsNotNull(müsteriKart.Oncelik);
            Assert.IsNotNull(müsteriKart.IslemTipi);
            Assert.IsNotNull(teknikKart.TeknikUzman);
        }

    }
}
