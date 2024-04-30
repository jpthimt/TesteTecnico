@ModelType TesteTecnicoManga.Usuarios
@Code
    ViewData("Title") = "Regitrar"
End Code

<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Registrar</title>
    <link rel="stylesheet" href="../Content/main.css">
</head>
<body>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div Class="login">
            <h1>Registrar</h1>
            <form method="post">
                <!-- Recebe o nome digitado -->
                @Html.EditorFor(Function(model) model.nome, New With {.htmlAttributes = New With {.type = "text", .name = "u", .placeholder = "Nome", .required = "required"}})
                <!-- Recebe o email digitado -->
                @Html.EditorFor(Function(model) model.email, New With {.htmlAttributes = New With {.type = "text", .name = "u", .placeholder = "Email", .required = "required"}})
                <!-- Recebe a senha digitada -->
                @Html.EditorFor(Function(model) model.senha, New With {.htmlAttributes = New With {.type = "password", .name = "p", .placeholder = "Password", .required = "required"}})
                <button type="submit" value="Registrar" class="btn btn-primary btn-block btn-large">Registrar</button>  <!-- Faz o envio das informações para o método Registrar -->
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