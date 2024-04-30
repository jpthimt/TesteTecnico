@ModelType TesteTecnicoManga.AlterarViewModel

@Code
    ViewData("Title") = "Alterar Senha"
End Code

<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Alterar Senha</title>
    <link rel="stylesheet" href="../Content/main.css">
</head>
<body>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()
        @<div class="login">
            <h1>Alterar senha</h1>
            <form method="post">
                <!-- Recebe a senha antiga digitada -->
                @Html.EditorFor(Function(model) model.OldPAssword, New With {.htmlAttributes = New With {.type = "password", .name = "p", .placeholder = "Antiga Senha", .required = "required"}})
                <!-- Recebe a senha nova digitada -->
                @Html.EditorFor(Function(model) model.NewPassword, New With {.htmlAttributes = New With {.type = "password", .name = "p", .placeholder = "Nova Senha", .required = "required"}})
                @Html.ValidationSummary(True, "", New With {.class = "text-danger"})    <!-- Mostra mensagem caso a senha antiga estaja errada -->
                <button type="submit" value="ChangePassword" class="btn btn-primary btn-block btn-large">Alterar</button>   <!-- Faz o envio das informações para o método AlterarSenha -->
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
