<?php 


    class UsuariosServices{
        
        public function pegarUrl(): string
        {
            return "https://cadastrousuario-api.herokuapp.com/Usuario";
        }

        public function exibirUsuarios(): array 
        {
            $url= "https://cadastrousuario-api.herokuapp.com/Usuario";
            $resultado = (file_get_contents($url));
            return  (json_decode($resultado));
        
        }

        public function cadastrarUsuario(string $json): void
        {
            $url = "https://cadastrousuario-api.herokuapp.com/Usuario";

            $headers = 
            [

                'Content-type: application/json',
                'Content-length:'.strlen($json)

            ];

            $context = stream_context_create
            ([

                'http' =>[
                    'method' => 'POST',
                    'header' => $headers,
                    'content'=>$json
                ]

            ]);

            file_get_contents($url,false,$context);

        }

        public function atualizarUsuario(string $json, string $id): void
        {

            $url = "https://cadastrousuario-api.herokuapp.com/Usuario/$id";

            $headers = 
            [

                'Content-type: application/json',
                'Content-length:'.strlen($json)

            ];

            $context = stream_context_create
            ([

                'http' =>[
                    'method' => 'PUT',
                    'header' => $headers,
                    'content'=>$json
                ]

            ]);

            file_get_contents($url,false,$context);

        }

        public function deletarUsuario(string $json, string $id): void
        {
            
            $url = "https://cadastrousuario-api.herokuapp.com/Usuario/$id";

            $headers = 
            [

                'Content-type: application/json',
                'Content-length:'.strlen($json)

            ];

            $context = stream_context_create
            ([

                'http' =>[
                    'method' => "DELETE",
                    'header' => $headers,
                    'content'=>$json
                ]

            ]);

            file_get_contents($url,false,$context);

        }

        public function redirecionar(string $url):void{
            header("Location: $url");
            die();
        }

    }
       
?>