using SafeCity2607last.Data;
using SafeCity2607last.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SafeCity2607last.Services
{
    public class Functional : IFunctional
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IRoles _roles;
        private readonly SuperAdminDefaultOptions _superAdminDefaultOptions;

        public Functional(UserManager<ApplicationUser> userManager,
           RoleManager<IdentityRole> roleManager,
           ApplicationDbContext context,
           SignInManager<ApplicationUser> signInManager,
           IRoles roles,
           IOptions<SuperAdminDefaultOptions> superAdminDefaultOptions)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _signInManager = signInManager;
            _roles = roles;
            _superAdminDefaultOptions = superAdminDefaultOptions.Value;
        }

      

        public async Task InitAppData()
        {
            try
            {
               
                await _context.TypeProposition.AddAsync(new TypeProposition { BillTypeName = "Default" });
                await _context.SaveChangesAsync();

                await _context.Mission.AddAsync(new Mission { BranchName = "Default" });
                await _context.SaveChangesAsync();

                await _context.Lieu.AddAsync(new Lieu { WarehouseName = "Default" });
                await _context.SaveChangesAsync();

                await _context.PropositionPublic.AddAsync(new PropositionPublic { CashBankName = "Default" });
                await _context.SaveChangesAsync();

                await _context.Currency.AddAsync(new Grade { CurrencyName = "Default", CurrencyCode = "USD" });
                await _context.SaveChangesAsync();

                await _context.TypeMessage.AddAsync(new TypeMessage { InvoiceTypeName = "Default" });
                await _context.SaveChangesAsync();

                await _context.PublicationPublic.AddAsync(new PublicationPublic { PaymentTypeName = "Default" });
                await _context.SaveChangesAsync();

                await _context.PropositionsControleurQualité.AddAsync(new PropositionsControleurQualité { PurchaseTypeName = "Default" });
                await _context.SaveChangesAsync();

                await _context.PropositionsAdmin.AddAsync(new PropositionsAdmin { SalesTypeName = "Default" });
                await _context.SaveChangesAsync();

                await _context.MessagePublic.AddAsync(new MessagePublic { ShipmentTypeName = "Default" });
                await _context.SaveChangesAsync();

                await _context.SujetPublication.AddAsync(new SujetPublication { UnitOfMeasureName = "PCS" });
                await _context.SaveChangesAsync();

                await _context.CommentairesdePublic.AddAsync(new CommentairesdePublic { ProductTypeName = "Default" });
                await _context.SaveChangesAsync();

                List<PublicationChercheurs> products = new List<PublicationChercheurs>() {
                    new PublicationChercheurs{ProductName = "Chai"},
                    new PublicationChercheurs{ProductName = "Chang"},
                    new PublicationChercheurs{ProductName = "Aniseed Syrup"},
                    new PublicationChercheurs{ProductName = "Chef Anton's Cajun Seasoning"},
                    new PublicationChercheurs{ProductName = "Chef Anton's Gumbo Mix"},
                    new PublicationChercheurs{ProductName = "Grandma's Boysenberry Spread"},
                    new PublicationChercheurs{ProductName = "Uncle Bob's Organic Dried Pears"},
                    new PublicationChercheurs{ProductName = "Northwoods Cranberry Sauce"},
                    new PublicationChercheurs{ProductName = "Mishi Kobe Niku"},
                    new PublicationChercheurs{ProductName = "Ikura"},
                    new PublicationChercheurs{ProductName = "Queso Cabrales"},
                    new PublicationChercheurs{ProductName = "Queso Manchego La Pastora"},
                    new PublicationChercheurs{ProductName = "Konbu"},
                    new PublicationChercheurs{ProductName = "Tofu"},
                    new PublicationChercheurs{ProductName = "Genen Shouyu"},
                    new PublicationChercheurs{ProductName = "Pavlova"},
                    new PublicationChercheurs{ProductName = "Alice Mutton"},
                    new PublicationChercheurs{ProductName = "Carnarvon Tigers"},
                    new PublicationChercheurs{ProductName = "Teatime Chocolate Biscuits"},
                    new PublicationChercheurs{ProductName = "Sir Rodney's Marmalade"}

                };
                await _context.PublicationChercheurs.AddRangeAsync(products);
                await _context.SaveChangesAsync();

                await _context.TypeAdmin.AddAsync(new TypeAdmin { CustomerTypeName = "Default" });
                await _context.SaveChangesAsync();

                List<Admin> customers = new List<Admin>() {
                    new Admin{CustomerName = "Hanari Carnes", Address = "Rua do Paço, 67"},
                    new Admin{CustomerName = "HILARION-Abastos", Address = "Carrera 22 con Ave. Carlos Soublette #8-35"},
                    new Admin{CustomerName = "Hungry Coyote Import Store", Address = "City Center Plaza 516 Main St."},
                    new Admin{CustomerName = "Hungry Owl All-Night Grocers", Address = "8 Johnstown Road"},
                    new Admin{CustomerName = "Island Trading", Address = "Garden House Crowther Way"},
                    new Admin{CustomerName = "Königlich Essen", Address = "Maubelstr. 90"},
                    new Admin{CustomerName = "La corne d'abondance", Address = "67, avenue de l'Europe"},
                    new Admin{CustomerName = "La maison d'Asie", Address = "1 rue Alsace-Lorraine"},
                    new Admin{CustomerName = "Laughing Bacchus Wine Cellars", Address = "1900 Oak St."},
                    new Admin{CustomerName = "Lazy K Kountry Store", Address = "12 Orchestra Terrace"},
                    new Admin{CustomerName = "Lehmanns Marktstand", Address = "Magazinweg 7"},
                    new Admin{CustomerName = "Let's Stop N Shop", Address = "87 Polk St. Suite 5"},
                    new Admin{CustomerName = "LILA-Supermercado", Address = "Carrera 52 con Ave. Bolívar #65-98 Llano Largo"},
                    new Admin{CustomerName = "LINO-Delicateses", Address = "Ave. 5 de Mayo Porlamar"},
                    new Admin{CustomerName = "Lonesome Pine Restaurant", Address = "89 Chiaroscuro Rd."},
                    new Admin{CustomerName = "Magazzini Alimentari Riuniti", Address = "Via Ludovico il Moro 22"},
                    new Admin{CustomerName = "Maison Dewey", Address = "Rue Joseph-Bens 532"},
                    new Admin{CustomerName = "Mère Paillarde", Address = "43 rue St. Laurent"},
                    new Admin{CustomerName = "Morgenstern Gesundkost", Address = "Heerstr. 22"},
                    new Admin{CustomerName = "Old World Delicatessen", Address = "2743 Bering St."}
                };
                await _context.Admin.AddRangeAsync(customers);
                await _context.SaveChangesAsync();

                await _context.TypeControleurQualité.AddAsync(new TypeControleurQualité { VendorTypeName = "Default" });
                await _context.SaveChangesAsync();

                List<ControleurdeQualité> vendors = new List<ControleurdeQualité>() {
                    new ControleurdeQualité{VendorName = "Exotic Liquids", Address = "49 Gilbert St."},
                    new ControleurdeQualité{VendorName = "New Orleans Cajun Delights", Address = "P.O. Box 78934"},
                    new ControleurdeQualité{VendorName = "Grandma Kelly's Homestead", Address = "707 Oxford Rd."},
                    new ControleurdeQualité{VendorName = "Tokyo Traders", Address = "9-8 Sekimai Musashino-shi"},
                    new ControleurdeQualité{VendorName = "Cooperativa de Quesos 'Las Cabras'", Address = "Calle del Rosal 4"},
                    new ControleurdeQualité{VendorName = "Mayumi's", Address = "92 Setsuko Chuo-ku"},
                    new ControleurdeQualité{VendorName = "Pavlova, Ltd.", Address = "74 Rose St. Moonie Ponds"},
                    new ControleurdeQualité{VendorName = "Specialty Biscuits, Ltd.", Address = "29 King's Way"},
                    new ControleurdeQualité{VendorName = "PB Knäckebröd AB", Address = "Kaloadagatan 13"},
                    new ControleurdeQualité{VendorName = "Refrescos Americanas LTDA", Address = "Av. das Americanas 12.890"},
                    new ControleurdeQualité{VendorName = "Heli Süßwaren GmbH & Co. KG", Address = "Tiergartenstraße 5"},
                    new ControleurdeQualité{VendorName = "Plutzer Lebensmittelgroßmärkte AG", Address = "Bogenallee 51"},
                    new ControleurdeQualité{VendorName = "Nord-Ost-Fisch Handelsgesellschaft mbH", Address = "Frahmredder 112a"},
                    new ControleurdeQualité{VendorName = "Formaggi Fortini s.r.l.", Address = "Viale Dante, 75"},
                    new ControleurdeQualité{VendorName = "Norske Meierier", Address = "Hatlevegen 5"},
                    new ControleurdeQualité{VendorName = "Bigfoot Breweries", Address = "3400 - 8th Avenue Suite 210"},
                    new ControleurdeQualité{VendorName = "Svensk Sjöföda AB", Address = "Brovallavägen 231"},
                    new ControleurdeQualité{VendorName = "Aux joyeux ecclésiastiques", Address = "203, Rue des Francs-Bourgeois"},
                    new ControleurdeQualité{VendorName = "New England Seafood Cannery", Address = "Order Processing Dept. 2100 Paul Revere Blvd."}
                };
                await _context.ControleurdeQualité.AddRangeAsync(vendors);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SendEmailBySendGridAsync(string apiKey, 
            string fromEmail, 
            string fromFullName, 
            string subject, 
            string message, 
            string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(fromEmail, fromFullName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email, email));
            await client.SendEmailAsync(msg);

        }

        public async Task SendEmailByGmailAsync(string fromEmail,
            string fromFullName,
            string subject,
            string messageBody,
            string toEmail,
            string toFullName,
            string smtpUser,
            string smtpPassword,
            string smtpHost,
            int smtpPort,
            bool smtpSSL)
        {
            var body = messageBody;
            var message = new MailMessage();
            message.To.Add(new MailAddress(toEmail, toFullName));
            message.From = new MailAddress(fromEmail, fromFullName);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = smtpUser,
                    Password = smtpPassword
                };
                smtp.Credentials = credential;
                smtp.Host = smtpHost;
                smtp.Port = smtpPort;
                smtp.EnableSsl = smtpSSL;
                await smtp.SendMailAsync(message);

            }

        }

        public async Task CreateDefaultSuperAdmin()
        {
            try
            {
                await _roles.GenerateRolesFromPagesAsync();

                ApplicationUser superAdmin = new ApplicationUser();
                superAdmin.Email = _superAdminDefaultOptions.Email;
                superAdmin.UserName = superAdmin.Email;
                superAdmin.EmailConfirmed = true;

                var result = await _userManager.CreateAsync(superAdmin, _superAdminDefaultOptions.Password);

                if (result.Succeeded)
                {
                    //add to user profile
                    UserProfile profile = new UserProfile();
                    profile.FirstName = "Super";
                    profile.LastName = "Admin";
                    profile.Email = superAdmin.Email;
                    profile.ApplicationUserId = superAdmin.Id;
                    await _context.UserProfile.AddAsync(profile);
                    await _context.SaveChangesAsync();

                    await _roles.AddToRoles(superAdmin.Id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<string> UploadFile(List<IFormFile> files, IHostingEnvironment env, string uploadFolder)
        {
            var result = "";

            var webRoot = env.WebRootPath;
            var uploads = System.IO.Path.Combine(webRoot, uploadFolder);
            var extension = "";
            var filePath = "";
            var fileName = "";


            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    extension = System.IO.Path.GetExtension(formFile.FileName);
                    fileName = Guid.NewGuid().ToString() + extension;
                    filePath = System.IO.Path.Combine(uploads, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    result = fileName;

                }
            }

            return result;
        }

    }
}
