<?php
if($_SERVER['REQUEST_METHOD'] === 'POST')
{
    include 'Services/cadastra-usuario-services.php';
    $usuariosServices = new UsuariosServices();

    $dados = [];

    $json = json_encode($dados);

    $usuariosServices->deletarUsuario($json, $_POST['id']);
    $usuariosServices->redirecionar("/cadastrarusuario");
}
?>
<!DOCTYPE html>
<html lang="pt-br">

<head>
    <link rel="stylesheet" type="text/css" href="style.css">
    <meta charset="UTF-8">
    <title>Excluir Usuario</title>
</head>

<body>
    <div id="container">
        <h1>Você realmente deseja excluir o usuário?</h1>
        <form method="POST" action="excluir-usuario.php">
            <p>
                <input type="hidden" name="id" value="<?php echo $_GET['id']?>" />
                <button class="botao">Excluir</button>
            </p>
        </form>
    </div>
</body>

</html>