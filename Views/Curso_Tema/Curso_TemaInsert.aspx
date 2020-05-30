<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MVCLaboratorio.Models.Curso_Tema>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Curso_TemaInsert</title>
</head>
<body>
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Datos</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.IdCurso) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.IdCurso) %>
                <%: Html.ValidationMessageFor(model => model.IdCurso) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.IdTema) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.IdTema) %>
                <%: Html.ValidationMessageFor(model => model.IdTema) %>
            </div>
            
            <p>
                <input type="submit" value="Insertar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Regresar a la lista", "Curso_Tema") %>
    </div>

</body>
</html>

