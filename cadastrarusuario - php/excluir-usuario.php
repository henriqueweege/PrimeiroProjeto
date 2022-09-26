<?php
include 'Services/cadastra-usuario-services.php';
$usuariosServices = new UsuariosServices();
if($_SERVER['REQUEST_METHOD'] === 'POST')
{
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
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous">
    <meta charset="UTF-8">
    <title>Excluir Usuario</title>
</head>

<body style="background-color: #34515f">
    <div id="container">
        <h1 id="titulo">Você realmente deseja excluir o usuário?</h1>
        <form method="POST" action="excluir-usuario.php">
            <p>
                <input type="hidden" name="id" value="<?php echo $_GET['id']?>" />
                <button class="btn btn-danger ">Excluir</button>
                <a class="btn btn-secondary " href="index.php">Voltar</a>
            </p>
        </form>
        
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-u1OknCvxWvY5kfmNBILK2hRnQC3Pr17a+RTT6rIHI7NnikvbZlHgTPOOmMi466C8" crossorigin="anonymous"></script>
</body>

</html>