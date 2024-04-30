@Code
    ViewData("Title") = "Página Inicial"
End Code
<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Página Inicial</title>
    <link rel="stylesheet" href="../Content/main.css">
</head>
<body>
    <div class="login">
        
        @Code
            If Session("IsLogged") Then 'Verifica se o Usuário está logado
                @<h1>Bem-vindo(a) @Session("UserName").ToString </h1>   'Mostra mensagem de boas-vindas com o nome do Usuário
                'Encaminha para a tela de alterar senha
                @<button class="btn btn-primary btn-block btn-large">@Html.ActionLink("Alterar Senha", "AlterarSenha", "Contas")</button>
                'Encaminha para o logout, voltando para a tela de login depois
                @<button class="btn btn-primary btn-block btn-large">@Html.ActionLink("Sair", "Sair", "Contas")</button>
            Else
                @<h1>Bem-vindo(a)</h1>
                'Encaminha para a tela de login
                @<button class="btn btn-primary btn-block btn-large">@Html.ActionLink("Entrar", "Entrar", "Contas")</button>
                'Encaminha para a tela de novo cadastro
                @<button class="btn btn-primary btn-block btn-large">@Html.ActionLink("Registrar", "Registrar", "Contas")</button>
            End If
        End Code
        <footer>
            <p>&copy; @DateTime.Now.Year - Teste Técnico - Manga Tecnologia</p>
        </footer>
    </div>
    @Section Scripts
        @Scripts.Render("~/bundles/jqueryval")
    End Section
</body>
</html>