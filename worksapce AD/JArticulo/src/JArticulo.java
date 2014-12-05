//package serpis.ad;

import java.math.BigInteger;
import java.sql.SQLException;
import java.util.Scanner;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.Statement;


public class JArticulo {
	
	private static Scanner scanner = new Scanner(System.in);
	
	public static void main(String[] args) throws ClassNotFoundException, SQLException {
		
		Connection connection = DriverManager.getConnection(
				"jdbc:mysql://localhost/dbprueba?user=root&password=sistemas");
		PreparedStatement preparedStatement;
		//ResultSet resulSet;
		
		System.out.println("/*********************\\");
		System.out.println("|Menu de mantenimiento|");
		System.out.println("\\*********************/");
		System.out.println("0 - SALIR");
		System.out.println("1 - NUEVO");
		System.out.println("2 - EDITAR");
		System.out.println("3 - ELIMINAR");
		System.out.println("4 - VER TABLA");
		
		int opcion = scanner.nextInt();
		scanner.reset();
		switch(opcion){
			case 0:
				System.out.println("Adios!");
				//resulSet.close();
				//preparedStatement.close();
				//connection.close();
				break;
			case 1:
				System.out.println("Nombre del articulo nuevo");
				String nombre = scanner.nextLine();
				nombre = scanner.nextLine();
				//BigInteger categoria [] = new BigInteger[1];
				System.out.println("Numero de la categoria a la que corresponde");
				int categoria = scanner.nextInt();
				System.out.println("Precio del articulo");
				float precio = scanner.nextFloat();
				
				//System.out.println(nombre + " - " + categoria[0] + " - " + precio);
				preparedStatement = connection.prepareStatement("INSERT INTO articulo(nombre, categoria, precio) VALUES (?,?,?)");
				preparedStatement.setString(1, nombre);
				preparedStatement.setInt(2, categoria);
				preparedStatement.setFloat(3, precio);
				int resulSet = preparedStatement.executeUpdate();
				//resulSet = preparedStatement.executeUpdate();
				//resulSet.close();
				
				preparedStatement.close();
				connection.close();
				break;
			case 2:
				break;
			case 3:
				break;
			case 4:
				break;
		}
		
		//resulSet.close();
		//preparedStatement.close();
		//connection.close();
		
	}
}
