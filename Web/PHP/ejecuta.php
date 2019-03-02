<?php
error_reporting(E_ERROR);

$sesion = new sesion();
//echo $sesion->generarClaveRegistro(); OK
//echo $sesion->claveExiste("TestKey"); OK
//echo $sesion->AsignarClave("Jesus","TestKey"); OK
//echo $sesion->registrarUsuario("Jesus", "prueba123", "TestKey"); OK
//echo $sesion->inicioSesion("Jesus","prueba123"); OK
//echo $sesion->guardaDatos("Jesus", "prueba123", "Dato", "TextoDelDato"); OK

switch($_GET["accion"]){
	case "registrarUsuario":
		$r = $sesion->registrarUsuario($_GET["Usuario"], $_GET["Contraseña"], $_GET["ReContraseña"], $_GET["claveRegistro"]);
		break;
	case "inicioSesion":
		$r = $sesion->inicioSesion($_GET["Usuario"], $_GET["Contraseña"]);
		break;
	case "generarClaveRegistro":
		$r = $sesion->generarClaveRegistro($_GET["codigoAdmin"]);
		break;
	case "esPremium":
		$r = $sesion->esPremium($_GET["Usuario"]);
		break;
	case "guardaDatos":
		$r = $sesion->guardaDatos($_GET["Usuario"], $_GET["Contraseña"], $_GET["ClaveSesion"], $_GET["DatoID"], $_GET["Dato"]);
		break;
	case "obtenDatos":
		$r = $sesion->obtenDatos($_GET["Usuario"], $_GET["Contraseña"], $_GET["ClaveSesion"], $_GET["DatoID"]);
		break;
	case "solicitaBorrar":
		$r = $sesion->solicitaBorrar($_GET["Usuario"], $_GET["Contraseña"], $_GET["ClaveSesion"], $_GET["QueBorrar"]);
		break;
	case "cambiaDatosPerfil":
		$r = $sesion->cambiaDatosPerfil($_GET["Usuario"], $_GET["Contraseña"], $_GET["ClaveSesion"], $_GET["QueCambiar"], $_GET["Cambio"]);
		break;
	case "admin":
		$r = $sesion->controlAdmin($_GET["Usuario"], $_GET["Contraseña"], $_GET["ClaveSesion"], $_GET["Accion"], $_GET["Afectado"]);
		break;
	case "enviarTicket":
		$r = $sesion->enviarTicket($_GET["Usuario"], $_GET["Contraseña"], $_GET["ClaveSesion"], $_GET["C"]);
		break;
	case "estadoTicket":
		$r = $sesion->estadoTicket($_GET["Usuario"], $_GET["Contraseña"], $_GET["ClaveSesion"]);
		break;
	case "cerrarTicket":
		$r = $sesion->cerrarTicket($_GET["Usuario"], $_GET["Contraseña"], $_GET["ClaveSesion"]);
		break;
	case "continuaTicket":
		$r = $sesion->continuaTicket($_GET["Usuario"], $_GET["Contraseña"], $_GET["ClaveSesion"], $_GET["C"]);
		break;
	case "cerrarSesion":
		$r = $sesion->cerrarSesion($_GET["Usuario"], $_GET["Contraseña"], $_GET["ClaveSesion"]);
		break;
	case "obtenAlertas":
		$r = $sesion->obtenAlertas($_GET["Usuario"], $_GET["Contraseña"], $_GET["ClaveSesion"]);
		break;
	default:
		$r = "ERROR:NO_ACCION";
}

echo $r;




class sesion{
	
	/////FUNCIÓN LOCAL [->]
	private function query($sql, $arg, $fetch = false){
		require "conexion.php";
		$q = $db->prepare($sql);
		$q->execute($arg);
		return $fetch ? $q->fetch(2) : $q;
	}
	
	private function bcrypt($contraseña){
		return password_hash($contraseña, PASSWORD_BCRYPT, ["cost" => 10]);
	}
	
	private function usuarioExiste($usuario){
		return $this->query("SELECT IDcuenta FROM Cuentas WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true)["IDcuenta"];
	}
	
	private function estaBaneado($usuario){
		return $this->query("SELECT Baneado FROM Cuentas WHERE IDcuenta = ?", array($this->obtenerIDusuario($usuario)), true)["Baneado"];
	}
	
	private function obtenerIDusuario($usuario){
		return $this->query("SELECT IDcuenta FROM Cuentas WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true)["IDcuenta"];
	}
	
	private function generarClaveSesion($usuario){
			$tamañoClave = 15;
			$alphaSesion = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
			$claveSesion = "";
			for ($i = 0; $i<$tamañoClave; $i++){
				$claveSesion .= $alphaSesion[mt_rand(0, strlen($alphaSesion) - 1)];
			}
		$this->query("UPDATE Cuentas SET claveSesion = ? WHERE Usuario COLLATE latin1_bin LIKE ?", array($claveSesion, $usuario));
		return $claveSesion;
	}
	
	private function obtenerClaveSesion($usuario){
		return $this->query("SELECT ClaveSesion FROM Cuentas WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true)["ClaveSesion"];
	}
	
	private function obtenerDato($DatoID, $usuario){
		if($DatoID == "Dato"){
			return $this->query("SELECT Dato FROM Datos WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true)["Dato"];
		}elseif($DatoID == "Dato2"){
			if(!$this->query("SELECT Premium FROM Cuentas WHERE IDcuenta = ?", array($this->obtenerIDusuario($usuario)), true)["Premium"]) return "ERROR:FUNCION_PREMIUM";
			return $this->query("SELECT Dato2 FROM Datos WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true)["Dato2"];
		}else{
			return "ID DE DATO INCORRECTO";
		}
	}
/////FUNCIÓN LOCAL [<-]

/////FUNCIÓN USUARIO [->]
	public function registrarUsuario($usuario, $contraseña, $recontraseña, $claveRegistro){
		if(empty($usuario) || empty($contraseña)|| empty($recontraseña) || empty($claveRegistro)) return "ERROR:FALTAN_PARAMETROS";
		if($this->usuarioExiste($usuario)) return "ERROR:USUARIO_EXISTE";
		if(strlen($usuario)>20 || strlen($usuario) < 3) return "ERROR:USUARIO_MUY_CORTO";
		if(strlen($contraseña) < 8) return "ERROR:CONTRASENA_MUY_CORTA";
		if($contraseña != $recontraseña) return "ERROR:CONTRASENAS_NO_COINCIDEN";
		if(!$this->AsignarClave($usuario, $claveRegistro)) return "ERROR:CLAVE_INVALIDA";
		$this->query("INSERT INTO Cuentas(Usuario, Contraseña) VALUES (?, ?)", array($usuario, $this->bcrypt($contraseña)));
		$this->query("INSERT INTO Datos(Usuario) VALUES(?)", array($usuario));
		return "OK:HECHO";
	}
	
	public function inicioSesion($usuario, $contraseña){
		if(empty($usuario) || empty($contraseña)) return "ERROR:FALTAN_PARAMETROS";
		if(!$this->usuarioExiste($usuario)) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->estaBaneado($usuario)) return "ERROR:USUARIO_BANEADO";
		$cryptcontraseña = $this->query("SELECT Contraseña FROM Cuentas WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true);
		if(!password_verify($contraseña, $cryptcontraseña["Contraseña"])) return "ERROR:CREDENCIALES_INVALIDOS";
		$ClaveSesion = $this->generarClaveSesion($usuario);
		return "OK:SESION_INICIADA:CLAVE_SESION:".$ClaveSesion;
	}
	
	public function esPremium($usuario){
		if(empty ($usuario)) return "ERROR:FALTAN_PARAMETROS";
		if(!$this->usuarioExiste($usuario)) return "ERROR:USUARIO_NO_EXISTE";
		return $this->query("SELECT Premium FROM Cuentas WHERE IDcuenta = ?", array($this->obtenerIDusuario($usuario)), true)["Premium"];
	}

	public function cerrarSesion($usuario, $contraseña, $clavesesion){
		if(empty($usuario) || empty($contraseña) || empty($clavesesion)) return "ERROR:FALTAN_PARAMETROS";
		if(!$this->usuarioExiste($usuario)) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->estaBaneado($usuario)) return "ERROR:USUARIO_BANEADO";
		$cryptcontraseña = $this->query("SELECT Contraseña FROM Cuentas WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true);
		if(!password_verify($contraseña, $cryptcontraseña["Contraseña"])) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->obtenerClaveSesion($usuario) != $clavesesion) return "ERROR:SESION_NO_VALIDA";
		$this->generarClaveSesion($usuario);
		return "OK:SESION_CERRADA";
	}
/////FUNCIÓN USUARIO [<-]

/////FUNCIÓN REGISTRAR CLAVE [->]
	public function generarClaveRegistro($admin, $tamaño = 10){
		if($admin != "MakerDev") return "ERROR:PRIVILEGIOS_INSUFICIENTES";
		$existe = false;
		do{
			$alpha = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
			$clave = "";
			for ($i = 0; $i<$tamaño; $i++){
				$clave .= $alpha[mt_rand(0, strlen($alpha) - 1)];
			}
			if($this->claveExiste($clave)) $existe = true;
		}while($existe);
		$this->query("INSERT INTO ClavesRegistro(claveRegistro) VALUES(?)", array($clave));
		return "CLAVE_REGISTRO:".$clave;
	}
	
	private function claveExiste($clave){
		return $this->query("SELECT claveRegistro FROM ClavesRegistro WHERE claveRegistro COLLATE latin1_bin LIKE ? AND Usuario IS NULL", array($clave), true)["claveRegistro"];
		
	}
	
	private function AsignarClave($usuario, $clave){
		if(!$this->claveExiste($clave)) return false;
		$this->query("UPDATE ClavesRegistro SET Usuario = ? WHERE claveRegistro COLLATE latin1_bin LIKE ?", array($usuario, $clave));
		return true;
	}
/////FUNCIÓN REGISTRAR CLAVE [<-]

/////FUNCIÓN GESTION DATOS [->]
	public function guardaDatos($usuario, $contraseña, $clavesesion, $DatoID, $Dato){
		if(empty($usuario) || empty($contraseña) || empty($clavesesion) || empty($DatoID) || empty($Dato)) return "ERROR:FALTAN_PARAMETROS";
		if(!$this->usuarioExiste($usuario)) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->estaBaneado($usuario)) return "ERROR:USUARIO_BANEADO";
		$cryptcontraseña = $this->query("SELECT Contraseña FROM Cuentas WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true);
		if(!password_verify($contraseña, $cryptcontraseña["Contraseña"])) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->obtenerClaveSesion($usuario) != $clavesesion) return "ERROR:SESION_NO_VALIDA";
		$this->query("UPDATE Datos SET $DatoID = ? WHERE Usuario COLLATE latin1_bin LIKE ?", array($Dato, $usuario));
		return "OK:DATOS_GUARDADOS";
	}

	public function obtenDatos($usuario, $contraseña, $clavesesion, $DatoID){
		if(empty($usuario) || empty($contraseña) || empty($clavesesion) || empty($DatoID)) return "ERROR:FALTAN_PARAMETROS";
		if(!$this->usuarioExiste($usuario)) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->estaBaneado($usuario)) return "ERROR:USUARIO_BANEADO";
		$cryptcontraseña = $this->query("SELECT Contraseña FROM Cuentas WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true);
		if(!password_verify($contraseña, $cryptcontraseña["Contraseña"])) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->obtenerClaveSesion($usuario) != $clavesesion) return "ERROR:SESION_NO_VALIDA";
		return "OK:DATO:".$this->obtenerDato($DatoID, $usuario);
	}
/////FUNCIÓN GESTION DATOS [<-]

/////FUNCIÓN GESTION PERFIL DE USUARIO [->]
	public function solicitaBorrar($usuario, $contraseña, $clavesesion, $queborrar){
		if(empty($usuario) || empty($contraseña) || empty($clavesesion) || empty($queborrar)) return "ERROR:FALTAN_PARAMETROS";
		if(!$this->usuarioExiste($usuario)) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->estaBaneado($usuario)) return "ERROR:USUARIO_BANEADO";
		$cryptcontraseña = $this->query("SELECT Contraseña FROM Cuentas WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true);
		if(!password_verify($contraseña, $cryptcontraseña["Contraseña"])) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->obtenerClaveSesion($usuario) != $clavesesion) return "ERROR:SESION_NO_VALIDA";
		if($queborrar == "BorrarCuenta"){
			$this->query("DELETE FROM Datos WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario));
			$this->query("DELETE FROM Cuentas WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario));
			$this->query("DELETE FROM ClavesRegistro WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario));
			$hayTicket = $this->query("SELECT IDTicket FROM Tickets WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true)["IDTicket"];
			if($hayTicket != ""){
				$this->query("DELETE FROM Tickets WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario));
			}
			require "conexion.php";
				$q = $db->prepare("SELECT * FROM Notificaciones");
				$q->execute();
	
				$result = $q -> fetchAll();
	
				$Borrar = "";
	
				foreach ($result as $row) {
					if($row['Personal'] == 1){
						if($row['Usuario'] == $usuario){
							$Borrar = $row['IDNotificacion'];
							$this->query("DELETE FROM Notificaciones WHERE IDNotificacion = ?", array($Borrar));
						}
					}
				}
			return "OK:";
		}elseif($queborrar == "BorrarDatos"){
			$this->query("UPDATE Datos SET Dato = ? WHERE Usuario COLLATE latin1_bin LIKE ?", array(NULL, $usuario));
			$this->query("UPDATE Datos SET Dato2 = ? WHERE Usuario COLLATE latin1_bin LIKE ?", array(NULL, $usuario));
			return "OK:";
		}else{
			return "ERROR:FALTAN_PARAMETROS";
		}
	}
	
	public function cambiaDatosPerfil($usuario, $contraseña, $clavesesion, $quecambiar, $cambio){
		if(empty($usuario) || empty($contraseña) || empty($clavesesion) || empty($quecambiar) || empty($cambio)) return "ERROR:FALTAN_PARAMETROS";
		if(!$this->usuarioExiste($usuario)) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->estaBaneado($usuario)) return "ERROR:USUARIO_BANEADO";
		$cryptcontraseña = $this->query("SELECT Contraseña FROM Cuentas WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true);
		if(!password_verify($contraseña, $cryptcontraseña["Contraseña"])) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->obtenerClaveSesion($usuario) != $clavesesion) return "ERROR:SESION_NO_VALIDA";
		if($quecambiar == "CambiarUsuario"){
			if(strlen($cambio)>20 || strlen($cambio) < 3) return "ERROR:USUARIO_MUY_CORTO";
			$this->query("UPDATE Cuentas SET Usuario = ? WHERE IDcuenta = ?", array($cambio, $this->obtenerIDusuario($usuario)));
			$this->query("UPDATE Datos SET Usuario = ? WHERE Usuario COLLATE latin1_bin LIKE ?", array($cambio, $usuario));
			$this->query("UPDATE ClavesRegistro SET Usuario = ? WHERE Usuario COLLATE latin1_bin LIKE ?", array($cambio, $usuario));
			return "OK:USUARIO:".$cambio;
		}elseif($quecambiar == "CambiarContraseña"){
			if(strlen($cambio) < 8) return "ERROR:CONTRASENA_MUY_CORTA";
			$this->query("UPDATE Cuentas SET Contraseña = ? WHERE IDcuenta = ?", array($this->bcrypt($cambio), $this->obtenerIDusuario($usuario)));
			return "OK:CONTRASEÑA_CAMBIADA";
		}else{
			return "ERROR:FALTAN_PARAMETROS";
		}
	}
/////FUNCIÓN GESTION PERFIL DE USUARIO [<-]

/////FUNCIÓN PANEL ADMIN [->]
	public function controlAdmin($usuario, $contraseña, $clavesesion, $accion, $afectado){
		if(empty($usuario) || empty($contraseña) || empty($clavesesion) || empty($accion) || empty($afectado)) return "ERROR:FALTAN_PARAMETROS";
		if(!$this->usuarioExiste($usuario)) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->estaBaneado($usuario)) return "ERROR:USUARIO_BANEADO";
		$cryptcontraseña = $this->query("SELECT Contraseña FROM Cuentas WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true);
		if(!password_verify($contraseña, $cryptcontraseña["Contraseña"])) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->obtenerClaveSesion($usuario) != $clavesesion) return "ERROR:SESION_NO_VALIDA";
		$esAdmin = $this->query("SELECT Premium FROM Cuentas WHERE IDcuenta = ?", array($this->obtenerIDusuario($usuario)), true)["Premium"];
		if($accion == "obtenerBans" && $esAdmin == "2"){
			require "conexion.php";
			$q = $db->prepare("SELECT * FROM Cuentas");
			$q->execute();

			$result = $q -> fetchAll();

			$Baneados = "OK:Bans:";

			foreach ($result as $row) {
				if($row['Baneado'] == 1){
					$Baneados = $Baneados.$row['Usuario'];
					$Baneados = $Baneados."&";
				}
			}
			if($Baneados != ""){
				return $Baneados."FIN";
			}else{
				return "NO_BANEADOS";
			}
		}
		if(!$this->usuarioExiste($afectado)) return "ERROR:USUARIO_NO_EXISTE";
		$esAfectadoAdmin = $this->query("SELECT Premium FROM Cuentas WHERE IDcuenta = ?", array($this->obtenerIDusuario($afectado)), true)["Premium"];
		if($esAdmin == "2" && $esAfectadoAdmin != "2"){
			if($accion == "Ban"){
				$this->query("UPDATE Cuentas SET Baneado = ? WHERE Usuario COLLATE latin1_bin LIKE ?", array("1", $afectado));
				return "OK:";
			}elseif($accion == "Unban"){
				$this->query("UPDATE Cuentas SET Baneado = ? WHERE Usuario COLLATE latin1_bin LIKE ?", array("0", $afectado));
				return "OK:";
			}elseif($accion == "Premium"){
				$this->query("UPDATE Cuentas SET Premium = ? WHERE Usuario COLLATE latin1_bin LIKE ?", array("1", $afectado));
				return "OK:";
			}elseif($accion == "Unpremium"){
				$this->query("UPDATE Cuentas SET Premium = ? WHERE Usuario COLLATE latin1_bin LIKE ?", array("0", $afectado));
				return "OK:";
			}elseif($accion == "BorrarDatos"){
				$this->query("UPDATE Datos SET Dato = ? WHERE Usuario COLLATE latin1_bin LIKE ?", array(NULL, $afectado));
				$this->query("UPDATE Datos SET Dato2 = ? WHERE Usuario COLLATE latin1_bin LIKE ?", array(NULL, $afectado));
				return "OK:";
			}elseif($accion == "BorrarCuenta"){
				$this->query("DELETE FROM Datos WHERE Usuario COLLATE latin1_bin LIKE ?", array($afectado));
				$this->query("DELETE FROM Cuentas WHERE Usuario COLLATE latin1_bin LIKE ?", array($afectado));
				$this->query("DELETE FROM ClavesRegistro WHERE Usuario COLLATE latin1_bin LIKE ?", array($afectado));
				$hayTicket = $this->query("SELECT IDTicket FROM Tickets WHERE Usuario COLLATE latin1_bin LIKE ?", array($afectado), true)["IDTicket"];
				if($hayTicket != ""){
					$this->query("DELETE FROM Tickets WHERE Usuario COLLATE latin1_bin LIKE ?", array($afectado));
				}
				require "conexion.php";
				$q = $db->prepare("SELECT * FROM Notificaciones");
				$q->execute();
	
				$result = $q -> fetchAll();
	
				$Borrar = "";
	
				foreach ($result as $row) {
					if($row['Personal'] == 1){
						if($row['Usuario'] == $afectado){
							$Borrar = $row['IDNotificacion'];
							$this->query("DELETE FROM Notificaciones WHERE IDNotificacion = ?", array($Borrar));
						}
					}
				}
				return "OK:";
			}elseif($accion == "CierraSesion"){
				$this->generarClaveSesion($afectado);
				return "OK:";
			}elseif($accion == "obtenerInfo"){
				$IDcuenta = $this->query("SELECT IDcuenta FROM Cuentas WHERE Usuario COLLATE latin1_bin LIKE ?", array($afectado), true)["IDcuenta"];
				$Baneado = $this->query("SELECT Baneado FROM Cuentas WHERE Usuario COLLATE latin1_bin LIKE ?", array($afectado), true)["Baneado"];
				$Premium = $this->query("SELECT Premium FROM Cuentas WHERE Usuario COLLATE latin1_bin LIKE ?", array($afectado), true)["Premium"];
				$ClaveRegistro = $this->query("SELECT claveRegistro FROM ClavesRegistro WHERE Usuario COLLATE latin1_bin LIKE ?", array($afectado), true)["claveRegistro"];
				$hayTicket = $this->query("SELECT IDTicket FROM Tickets WHERE Usuario COLLATE latin1_bin LIKE ?", array($afectado), true)["IDTicket"];
				if($hayTicket != ""){
					$Tickets = "Si";
				}else{
					$Tickets = "No";
				}
				return "OK:INFO:".$IDcuenta."&".$Baneado."&".$Premium."&".$ClaveRegistro."&".$Tickets;
			}else{
				return "ERROR:FALTAN_PARAMETROS";
			}		
		}else{
			return "ERROR:PRIVILEGIOS_INSUFICIENTES";
		}
	}
/////FUNCIÓN PANEL ADMIN [<-]

/////FUNCIÓN SOPORTE [->]
	public function enviarTicket($usuario, $contraseña, $clavesesion, $contenido){
		if(empty($usuario) || empty($contraseña) || empty($clavesesion) || empty($contenido)) return "ERROR:FALTAN_PARAMETROS";
		if(!$this->usuarioExiste($usuario)) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->estaBaneado($usuario)) return "ERROR:USUARIO_BANEADO";
		$cryptcontraseña = $this->query("SELECT Contraseña FROM Cuentas WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true);
		if(!password_verify($contraseña, $cryptcontraseña["Contraseña"])) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->obtenerClaveSesion($usuario) != $clavesesion) return "ERROR:SESION_NO_VALIDA";
		$hayTicket = $this->query("SELECT IDTicket FROM Tickets WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true)["IDTicket"];
		if($hayTicket != ""){
			return "ERROR:Ya tienes un Ticket de Soporte abierto, Ticket:#".$hayTicket;
		}else{
			$this->query("INSERT INTO Tickets(Usuario, Contenido, Respuesta, Estado) VALUES (?, ?, ?, ?)", array($usuario, $contenido, "Esperando Respuesta...", "Abierto"));
			return "OK:TICKET_ENVIADO";
		}
	}
	
	public function estadoTicket($usuario, $contraseña, $clavesesion){
		if(empty($usuario) || empty($contraseña) || empty($clavesesion)) return "ERROR:FALTAN_PARAMETROS";
		if(!$this->usuarioExiste($usuario)) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->estaBaneado($usuario)) return "ERROR:USUARIO_BANEADO";
		$cryptcontraseña = $this->query("SELECT Contraseña FROM Cuentas WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true);
		if(!password_verify($contraseña, $cryptcontraseña["Contraseña"])) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->obtenerClaveSesion($usuario) != $clavesesion) return "ERROR:SESION_NO_VALIDA";
		$hayTicket = $this->query("SELECT IDTicket FROM Tickets WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true)["IDTicket"];
		if($hayTicket != ""){
			$contenido = $this->query("SELECT Contenido FROM Tickets WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true)["Contenido"];
			$respuesta = $this->query("SELECT Respuesta FROM Tickets WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true)["Respuesta"];
			$estado = $this->query("SELECT Estado FROM Tickets WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true)["Estado"];
			return "OK:EsTi".$hayTicket."&".$contenido."&".$respuesta."&".$estado;
		}else{
			return "NO_TICKET";
		}
	}
	
	public function cerrarTicket($usuario, $contraseña, $clavesesion){
		if(empty($usuario) || empty($contraseña) || empty($clavesesion)) return "ERROR:FALTAN_PARAMETROS";
		if(!$this->usuarioExiste($usuario)) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->estaBaneado($usuario)) return "ERROR:USUARIO_BANEADO";
		$cryptcontraseña = $this->query("SELECT Contraseña FROM Cuentas WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true);
		if(!password_verify($contraseña, $cryptcontraseña["Contraseña"])) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->obtenerClaveSesion($usuario) != $clavesesion) return "ERROR:SESION_NO_VALIDA";
		$hayTicket = $this->query("SELECT IDTicket FROM Tickets WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true)["IDTicket"];
		if($hayTicket != ""){
			$this->query("DELETE FROM Tickets WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario));
			return "OK:TICKET_CERRADO";
		}else{
			return "ERROR:NO_TICKET";
		}
	}
	
	public function continuaTicket($usuario, $contraseña, $clavesesion, $contenido){
		if(empty($usuario) || empty($contraseña) || empty($clavesesion) || empty($contenido)) return "ERROR:FALTAN_PARAMETROS";
		if(!$this->usuarioExiste($usuario)) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->estaBaneado($usuario)) return "ERROR:USUARIO_BANEADO";
		$cryptcontraseña = $this->query("SELECT Contraseña FROM Cuentas WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true);
		if(!password_verify($contraseña, $cryptcontraseña["Contraseña"])) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->obtenerClaveSesion($usuario) != $clavesesion) return "ERROR:SESION_NO_VALIDA";
		$hayTicket = $this->query("SELECT IDTicket FROM Tickets WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true)["IDTicket"];
		if($hayTicket != ""){
			$estadoTicket = $this->query("SELECT Estado FROM Tickets WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true)["Estado"];
			if($estadoTicket=="Esperando Respuesta"){
			$this->query("UPDATE Tickets SET Contenido = ? WHERE Usuario COLLATE latin1_bin LIKE ?", array($contenido, $usuario));
			$this->query("UPDATE Tickets SET Estado = ? WHERE Usuario COLLATE latin1_bin LIKE ?", array("Abierto", $usuario));
			return "OK:TICKET_ENVIADO";
			}else{
			return "ERROR:TICKET_NO_DISPONIBLE";
			}
		}else{
			return "ERROR:NO_TICKET";
		}
	}

	public function adminTicket($usuario, $contraseña, $clavesesion){
	
	}
/////FUNCIÓN SOPORTE [<-]

/////FUNCIÓN NOTIFICACIONES [->]
	public function obtenAlertas($usuario, $contraseña, $clavesesion){
		if(empty($usuario) || empty($contraseña) || empty($clavesesion)) return "ERROR:FALTAN_PARAMETROS";
		if(!$this->usuarioExiste($usuario)) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->estaBaneado($usuario)) return "ERROR:USUARIO_BANEADO";
		$cryptcontraseña = $this->query("SELECT Contraseña FROM Cuentas WHERE Usuario COLLATE latin1_bin LIKE ?", array($usuario), true);
		if(!password_verify($contraseña, $cryptcontraseña["Contraseña"])) return "ERROR:CREDENCIALES_INVALIDOS";
		if($this->obtenerClaveSesion($usuario) != $clavesesion) return "ERROR:SESION_NO_VALIDA";
		require "conexion.php";
		$q = $db->prepare("SELECT * FROM Notificaciones");
		$q->execute();

		$result = $q -> fetchAll();

		$hayAlerta = "";

		foreach( $result as $row ) {
			if($row['Personal'] == "1"){
				if($row['Usuario'] == $usuario){
					$hayAlerta = $hayAlerta."OK:NotiT";
					$hayAlerta = $hayAlerta.$row['Titulo'];
					$hayAlerta = $hayAlerta."&";
					$hayAlerta = $hayAlerta.$row['Contenido'];
					$hayAlerta = $hayAlerta."&";
					$hayAlerta = $hayAlerta."Privado";
					$hayAlerta = $hayAlerta."&";
					$hayAlerta = $hayAlerta."FIN&";
				}
			}else{
				$hayAlerta = $hayAlerta."OK:NotiT";
				$hayAlerta = $hayAlerta.$row['Titulo'];
				$hayAlerta = $hayAlerta."&";
				$hayAlerta = $hayAlerta.$row['Contenido'];
				$hayAlerta = $hayAlerta."&";
				$hayAlerta = $hayAlerta."Publico";
				$hayAlerta = $hayAlerta."&";
				$hayAlerta = $hayAlerta."FIN&";
			}
		}
		if($hayAlerta != ""){
			return $hayAlerta."FINARCHIVO";
		}else{
			return "NO_NOTIFICACION";
		}
	}
/////FUNCIÓN NOTIFICACIONES [<-]
}
?>