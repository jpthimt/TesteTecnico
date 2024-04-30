Imports System.Web.Mvc
Imports System.Web.Security
Imports System.Linq
Imports System.Web.HttpContext


Namespace Controllers
    Public Class ContasController
        Inherits Controller

        'Recebe as entidade do banco de dados, no caso a tabela Usuarios
        Dim entity As New teste_tecnicoEntities()

        Function Entrar() As ActionResult
            Return View()
        End Function

        Function Registrar() As ActionResult
            Return View()
        End Function

        Function AlterarSenha() As ActionResult
            Return View()
        End Function

        'Método para o login
        <HttpPost>
        Function Entrar(credentials As LoginViewModel) As ActionResult
            'Verifica se o Usuário existe no banco de dados
            Dim userExist As Boolean = entity.Usuarios.Any(Function(x) x.email.Equals(credentials.Email) And x.senha.Equals(credentials.Senha))
            If (userExist) Then
                'Variável "u" recebe o Usuário encontrado
                Dim u As Usuarios = entity.Usuarios.FirstOrDefault(Function(x) x.email.Equals(credentials.Email) And x.senha.Equals(credentials.Senha))
                Session("UserName") = u.nome    'Armazena em uma sessão o nome do Usuário
                Session("UserId") = u.id    'Armazena em uma sessão o id do Usuário
                Session("IsLogged") = True  'Define a sessão como verdadeira, indicando que há um Usuário logado
                Return RedirectToAction("Index", "Home")    'Encaminha para a Página Inicial
            End If
            ModelState.AddModelError("", "Nome ou Senha incorretos")    'Mostra mensagem de erro se o usuário não foi encontrado
            Return View()   'Mostra a tela de Login
        End Function

        'Método para o cadastro de um novo Usuário
        <HttpPost>
        Function Registrar(userinfo As Usuarios) As ActionResult
            'Recebe as informações do formulário e adiciona no banco de dados
            entity.Usuarios.Add(userinfo)
            entity.SaveChanges()
            Return RedirectToAction("Entrar")   'Encaminha para a página de Login
        End Function

        'Método para fazer o Logout
        Function Sair() As ActionResult
            Session("IsLogged") = False 'Define a sessão como falsa para mostrar que não tem Usuário logado
            Return RedirectToAction("Entrar")   'Encaminha para a página de Login
        End Function

        'Método para alterar a senha de um Usuário
        <HttpPost>
        Function AlterarSenha(infos As AlterarViewModel) As ActionResult
            Dim idUser = Integer.Parse(Session("UserId").ToString())    'Armazena o id do Usuário logado
            Dim u As Usuarios = entity.Usuarios.FirstOrDefault(Function(x) x.id.Equals(idUser)) 'Busca e armazena os dados do Usuário logado 
            If (u.senha.Equals(infos.OldPAssword)) Then
                u.senha = infos.NewPassword 'Troca o valor da senha antiga pela nova
                entity.SaveChanges()
                Session("IsLogged") = False 'Define como falso para realizar o login novamente com a nova senha
                Return RedirectToAction("Entrar")   'Encaminha para a página de Login
            End If
            ModelState.AddModelError("", "Senha incorreta") 'Mostra erro se a senha antiga estiver errada
            Return View()   'Volta para a tela de Alterar Senha
        End Function
    End Class
End Namespace