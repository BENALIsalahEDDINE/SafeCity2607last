using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeCity2607last.Pages
{
    public static class MainMenu
    {
        
        public static class Admin
        {
            public const string PageName = "Admins";
            public const string RoleName = "Admins";
            public const string Path = "/Admin/Index";
            public const string ControllerName = "Admin";
            public const string ActionName = "Index";
        }

        public static class ControleurdeQualité
        {
            public const string PageName = "Controleur de Qualité";
            public const string RoleName = "Controleur de Qualité";
            public const string Path = "/ControleurdeQualité/Index";
            public const string ControllerName = "ControleurdeQualité";
            public const string ActionName = "Index";
        }

      
       

        

       


        public static class Proposition
        {
            public const string PageName = "Proposition";
            public const string RoleName = "Proposition";
            public const string Path = "/Proposition/Index";
            public const string ControllerName = "Proposition";
            public const string ActionName = "Index";
        }


        public static class Publication
        {
            public const string PageName = "Publication";
            public const string RoleName = "Publication";
            public const string Path = "/Publication/Index";
            public const string ControllerName = "Publication";
            public const string ActionName = "Index";
        }

        public static class CommentairesdePublic
        {
            public const string PageName = "Commentaires";
            public const string RoleName = "Commentaires de Public";
            public const string Path = "/CommentairesdePublic/Index";
            public const string ControllerName = "CommentairesdePublic";
            public const string ActionName = "Index";
        }



        public static class MessagePublic
        {
            public const string PageName = "Message";
            public const string RoleName = "Message Public";
            public const string Path = "/MessagePublic/Index";
            public const string ControllerName = "MessagePublic";
            public const string ActionName = "Index";

        }
        public static class User
        {
            public const string PageName = "User";
            public const string RoleName = "User";
            public const string Path = "/UserRole/Index";
            public const string ControllerName = "UserRole";
            public const string ActionName = "Index";
        }

       
        public static class ChangePassword
        {
            public const string PageName = "Change Password";
            public const string RoleName = "Change Password";
            public const string Path = "/UserRole/ChangePassword";
            public const string ControllerName = "UserRole";
            public const string ActionName = "ChangePassword";
        }

        public static class Role
        {

            public const string PageName = "Role";
            public const string RoleName = "Role";
            public const string Path = "/UserRole/Role";
            public const string ControllerName = "UserRole";
            public const string ActionName = "Role";
        }

        public static class ChangeRole
        {
            public const string PageName = "Change Role";
            public const string RoleName = "Change Role";
            public const string Path = "/UserRole/ChangeRole";
            public const string ControllerName = "UserRole";
            public const string ActionName = "ChangeRole";
        }
        public static class Chercheur
        {
            public const string PageName = "Chercheur";
            public const string RoleName = "Chercheur";
            public const string Path = "/Chercheur/Index";
            public const string ControllerName = "Chercheur";
            public const string ActionName = "Index";
        }

        public static class Statistiques
        {
            public const string PageName = "Statistiques";
            public const string RoleName = "Statistiques";
            public const string Path = "/Statistiques/Index";
            public const string ControllerName = "Statistiques";
            public const string ActionName = "Index";
        }

    }
}
