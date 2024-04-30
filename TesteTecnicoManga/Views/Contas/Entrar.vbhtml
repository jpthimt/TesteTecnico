@ModelType TesteTecnicoManga.LoginViewModel
@Code
    ViewData("Title") = "Entrar"
End Code

<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Entrar</title>
    <link rel="stylesheet" href="../Content/main.css">
</head>
<body>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()
        @<div class="login">
            <h1>Login</h1>
            <form method="post">
                <!-- Recebe o email digitado -->
                @Html.EditorFor(Function(model) model.Email, New With {.htmlAttributes = New With {.type = "text", .name = "u", .placeholder = "Email", .required = "required"}})
                <!-- Recebe a senha digitada -->
                @Html.EditorFor(Function(model) model.Senha, New With {.htmlAttributes = New With {.type = "password", .name = "p", .placeholder = "Password", .required = "required"}})
                @Html.ValidationSummary(True, "", New With {.class = "text-danger"})    <!-- Mostra mensagem caso email ou senha estajam errados -->
                <button type="submit" value="Login" class="btn btn-primary btn-block btn-large">Entrar</button> <!-- Faz o envio das informações para o método Entrar -->
                <button class="btn btn-primary btn-block btn-large">@Html.ActionLink("Voltar", "Index", "Home")</button>    <!-- Encaminha para a Página Inicial -->
            </form>
            <footer>
                <p>&copy; @DateTime.Now.Year - Teste Técnico - Manga Tecnologia</p>
            </footer>
        </div>
    End Using
    @Section Scripts
        @Scripts.Render("~/bundles/jqueryval")
    End Section
</body>
</html>