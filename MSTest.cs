using Microsoft.AspNetCore.Routing;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTestAutomation
{
    public class MSAutoTest
    {
        IWebDriver driver;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        public void NavigateToRegisterPage()
        {
            driver.Navigate().GoToUrl("http://localhost:5074/Register"); // Thay bằng URL thực tế
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Name("Koishowaccount.AccountId"))); // Đợi cho đến khi phần tử có sẵn
        }

        [Test]
        public void ktratrungAccountID()
        {
            NavigateToRegisterPage();

            driver.FindElement(By.Name("Koishowaccount.AccountId")).SendKeys("1001"); // Id trùng
            driver.FindElement(By.Name("Koishowaccount.Username")).SendKeys("username");
            driver.FindElement(By.Name("Koishowaccount.Password")).SendKeys("@123");
            driver.FindElement(By.Name("Koishowaccount.Role")).SendKeys("Member");

            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(5000);
            var errorMessage = driver.FindElement(By.CssSelector(".toast-message")).Text;
            NUnit.Framework.Assert.That(errorMessage.Contains("Id or username is already in use"), Is.True, "Registration should fail with an error message for duplicate data.");
        }

        [Test]
        public void ktratrungUsername()
        {
            NavigateToRegisterPage();

            driver.FindElement(By.Name("Koishowaccount.AccountId")).SendKeys("10010");
            driver.FindElement(By.Name("Koishowaccount.Username")).SendKeys("member1");//Username trùng 
            driver.FindElement(By.Name("Koishowaccount.Password")).SendKeys("@123");
            driver.FindElement(By.Name("Koishowaccount.Role")).SendKeys("Member");

            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(5000);
            var errorMessage = driver.FindElement(By.CssSelector(".toast-message")).Text;
            NUnit.Framework.Assert.That(errorMessage.Contains("Id or username is already in use"), Is.True, "Registration should fail with an error message for duplicate data.");
        }

        [Test]
        public void ktraDulieuHople()
        {
            NavigateToRegisterPage();

            driver.FindElement(By.Name("Koishowaccount.AccountId")).SendKeys("AccountId123"); //Id mới
            driver.FindElement(By.Name("Koishowaccount.Username")).SendKeys("newusername");//Username mới
            driver.FindElement(By.Name("Koishowaccount.Password")).SendKeys("@123");
            driver.FindElement(By.Name("Koishowaccount.Role")).SendKeys("Member");

            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(5000);
            var successMessage = driver.FindElement(By.CssSelector(".toast-message")).Text;
            NUnit.Framework.Assert.That(successMessage.Contains("Success Register!"), Is.True, "Registration should succeed with a success message.");
        }
        [Test]
        public void KtraMauLogin()
        {
            driver.Navigate().GoToUrl("http://localhost:5074/Login"); // Truy cập trang đăng nhập
            Thread.Sleep(2000);

            // Kiểm tra xem form đăng nhập có hiển thị hay không
            var loginForm = driver.FindElement(By.Id("loginForm"));
            NUnit.Framework.Assert.That(loginForm.Displayed, Is.True, "Login form should be displayed."); // Kiểm tra form đăng nhập
        }
        [Test]
        public void KtraLoginHopLe()
        {
            driver.Navigate().GoToUrl("http://localhost:5074/Login"); // Truy cập trang đăng nhập
            Thread.Sleep(2000);

            // Nhập thông tin đăng nhập hợp lệ
            driver.FindElement(By.Id("loginUsername")).SendKeys("member1"); // Nhập tên người dùng
            driver.FindElement(By.Id("loginPassword")).SendKeys("@123"); // Nhập mật khẩu hợp lệ

            // Nhấn nút đăng nhập
            driver.FindElement(By.CssSelector(".submit")).Click();
            Thread.Sleep(2000);

            // Kiểm tra nếu đăng nhập thành công (chuyển trang tới /MyProfile)
            NUnit.Framework.Assert.That(driver.Url, Is.EqualTo("http://localhost:5074/MyProfile"), "User should be redirected to MyProfile page after successful login.");
        }
        [Test]
        public void KtraLoginKhongHopLe()
        {
            driver.Navigate().GoToUrl("http://localhost:5074/Login"); // Truy cập trang đăng nhập
            Thread.Sleep(2000);

            // Nhập thông tin đăng nhập sai
            driver.FindElement(By.Id("loginUsername")).SendKeys("member?"); // Nhập tên người dùng sai
            driver.FindElement(By.Id("loginPassword")).SendKeys("@123"); // Nhập mật khẩu sai

            // Nhấn nút đăng nhập
            driver.FindElement(By.CssSelector(".submit")).Click();
            Thread.Sleep(2000);

            // Kiểm tra thông báo lỗi
            var errorMessage = driver.FindElement(By.CssSelector(".alert-danger")).Text;
            NUnit.Framework.Assert.That(errorMessage, Is.EqualTo("Tên người dùng hoặc mật khẩu không đúng."), "Error message should be displayed for failed login.");
        }
        [Test]
        public void KtraMauMyprofile()
        {
            driver.Navigate().GoToUrl("http://localhost:5074/MyProfile"); // Trang cá nhân
            Thread.Sleep(2000);

            driver.FindElement(By.CssSelector("button")).Click();
            Thread.Sleep(1000);

            // Thử gửi mẫu mà không điền thông tin
            driver.FindElement(By.CssSelector("button[type='button']")).Click(); // Gửi mẫu đăng ký
            Thread.Sleep(1000);

            // Kiểm tra thông báo lỗi
            var alertText = driver.SwitchTo().Alert().Text;
            NUnit.Framework.Assert.That(alertText, Is.EqualTo("Vui lòng điền đầy đủ thông tin."), "Alert message should be correct for empty form submission."); // Kiểm tra thông báo lỗi khi gửi form trống
        }

        [Test]
        public void KtraDaThamgia()
        {
            // Giả sử người dùng đã đăng ký tham gia cuộc thi
            driver.Navigate().GoToUrl("http://localhost:5074/MyProfile"); // Trang cá nhân
            Thread.Sleep(2000);

            // Nhấn nút "Đăng ký tham gia"
            driver.FindElement(By.CssSelector("button")).Click();
            Thread.Sleep(1000);

            // Điền thông tin vào mẫu đăng ký
            driver.FindElement(By.Id("name")).SendKeys("Test User");
            driver.FindElement(By.Id("address")).SendKeys("Test Address");
            driver.FindElement(By.Id("phone")).SendKeys("123456789");
            driver.FindElement(By.Id("fishSize")).SendKeys("20");
            driver.FindElement(By.Id("category")).SendKeys("Category1");
            driver.FindElement(By.Id("competition")).SendKeys("Competition1");
            driver.FindElement(By.Id("gender")).SendKeys("male");

            // Gửi mẫu đăng ký
            driver.FindElement(By.CssSelector("button[type='button']")).Click();
            Thread.Sleep(1000);

            // Kiểm tra nếu người dùng đã đăng ký tham gia cuộc thi
            var alertText = driver.SwitchTo().Alert().Text;
            NUnit.Framework.Assert.That(alertText, Is.EqualTo("Bạn đã đăng ký tham gia cuộc thi này."), "User should not be able to register multiple times."); // Kiểm tra thông báo khi người dùng đăng ký trùng
        }

        [Test]
        public void KtraDangKyHopLe()
        {
            driver.Navigate().GoToUrl("http://localhost:5074/MyProfile"); // Trang cá nhân
            Thread.Sleep(2000);

            driver.FindElement(By.CssSelector("button")).Click();
            Thread.Sleep(1000);

            // Điền thông tin vào mẫu đăng ký
            driver.FindElement(By.Id("name")).SendKeys("Test User");
            driver.FindElement(By.Id("address")).SendKeys("Test Address");
            driver.FindElement(By.Id("phone")).SendKeys("123456789");
            driver.FindElement(By.Id("fishSize")).SendKeys("20");
            driver.FindElement(By.Id("category")).SendKeys("Category1");
            driver.FindElement(By.Id("competition")).SendKeys("Competition1");
            driver.FindElement(By.Id("gender")).SendKeys("male");

            // Gửi mẫu đăng ký
            driver.FindElement(By.CssSelector("button[type='button']")).Click();
            Thread.Sleep(1000);

            // Kiểm tra thông báo thành công
            var alertText = driver.SwitchTo().Alert().Text;
            NUnit.Framework.Assert.That(alertText, Is.EqualTo("Đăng ký thành công!"), "User should be registered successfully."); // Kiểm tra thông báo thành công khi đăng ký
        }
        [Test]
        public void KtraThemCaKoiHopLe()
        {
            driver.Navigate().GoToUrl("http://localhost:5074/AddFish"); // Truy cập trang đăng nhập
            Thread.Sleep(2000);
            driver.FindElement(By.Name("name")).SendKeys("Koi Fish 01");
            driver.FindElement(By.Name("description")).SendKeys("Cá Koi, 2 năm tuổi, 30cm");

            // Giả sử bạn đang chọn một ảnh cá Koi hợp lệ
            var imageInput = driver.FindElement(By.Name("image"));
            string filePath = @"D:\ảnh koi\koi2.jpg"; // Đảm bảo file ảnh tồn tại tại đường dẫn này
            imageInput.SendKeys(filePath);

            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(3000); // Chờ phản hồi

            // Kiểm tra xem thông báo thành công có xuất hiện không
            var successMessage = driver.FindElement(By.CssSelector(".toast-message")).Text;
            NUnit.Framework.Assert.That(successMessage.Contains("Thêm Cá"), Is.True, "Thêm cá Koi không thành công.");
        }
        [Test]
        public void KtraThemCaKoiThieuThongTin()
        {
            driver.Navigate().GoToUrl("http://localhost:5074/AddFish"); // Truy cập trang đăng nhập
            Thread.Sleep(2000);
            driver.FindElement(By.Name("name")).SendKeys(""); // Không điền tên cá
            driver.FindElement(By.Name("description")).SendKeys("Cá Koi, 2 năm tuổi, 30cm");

            var imageInput = driver.FindElement(By.Name("image"));
            string filePath = @"D:\ảnh koi\koi2.jpg"; ;
            imageInput.SendKeys(filePath);

            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(3000);

            var errorMessage = driver.FindElement(By.CssSelector(".toast-message")).Text;
            NUnit.Framework.Assert.That(errorMessage.Contains("Tên Cá không thể để trống"), Is.True, "Không hiển thị lỗi khi thiếu tên cá.");
        }

        [TearDown]
        public void CloseTest()
        {
            driver.Quit();
        }
    }
}
