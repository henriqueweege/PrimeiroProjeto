<?php
include 'Services/cadastra-usuario-services.php';
$usuariosServices = new UsuariosServices();
$usuarios = $usuariosServices->exibirUsuarios();
?>


<!DOCTYPE html>
<html lang="pt-br">

<head>
    <title>Usuários Cadastrados</title>
    <meta charset="UTF-8">
    <link rel="stylesheet" type="text/css" href="style.css">
</head>

<body>
    <div id="container">
        <a class="botao" href="adicionar-usuario.php" id="botao-adicionar">Adicionar Usuário</a>
        <h1>Usuários Cadastrados</h1>
        <div>
        <?php
        foreach($usuarios as $value ){?>
            <div id="usuario">
                <h4><?= "$value->firstName  $value->surName"  ?></h4>
                <nav>
                    <a class="botao" href="editar-usuario.php?id=<?php echo $value->id;?>">Editar</a>
                    <a class="botao" href="excluir-usuario.php?id=<?php echo $value->id;?>">Excluir</a>
                </nav>
            </div>
        <?php } ?>
        </div>
    </div>
</body>
</html>