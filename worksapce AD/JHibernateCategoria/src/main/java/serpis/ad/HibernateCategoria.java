package serpis.ad;

import javax.persistence.EntityManager;
import javax.persistence.Persistence;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

import org.hibernate.persister.entity.Queryable;



public class HibernateCategoria {
	private static EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("serpis.ad.jpa.mysql");
	private static EntityManager entityManager;
	
	public static void main(String [] args){
		
		//entityManagerFactory = Persistence.createEntityManagerFactory("serpis.ad.jpa.mysql");
		
		Mostrar();
		
		Insertar("juan");
		
        Eliminar(31);
        
        Editar(32,"Raul");
        
        Mostrar();
        
        entityManagerFactory.close();
		
	}
	
	public static void Mostrar(){
		//Show Inicio
		entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
        List<Categoria> result = entityManager.createQuery( "from Categoria", Categoria.class ).getResultList();
		for ( Categoria categoria : result ) {
			System.out.println( "Categoria (" + categoria.getNombre() + ") : " + categoria.getId() );
		}
        entityManager.getTransaction().commit();
        entityManager.close();
        //Show Fin
	}
	
	public static void Insertar(String nombre){
		// Insert Inicio
		entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		//entityManager.persist( new Categoria( "asdqewa"  ));
		//entityManager.persist( new Categoria( "asdqwe"   ));
		Categoria categoriaObj = new Categoria();
		categoriaObj.setNombre(nombre);
		entityManager.persist(categoriaObj);
		entityManager.getTransaction().commit();
		entityManager.close();
		// Insert Fin
	}
	
	public static void Eliminar(long id){
		//Delet Inicio
        /*
        //Forma cutre
        entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();	
		String deleteQuery="delete from Categoria where id=24";
		entityManager.createQuery(deleteQuery).executeUpdate();
		
		entityManager.getTransaction().commit();
        entityManager.close();
        //Fin Forma cutre
        */
        //Forma ORM
        entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		//long id = 25;
		Categoria categoria = entityManager.find(Categoria.class, id);
		entityManager.remove(categoria);
		
		entityManager.getTransaction().commit();
        entityManager.close();
        //Fin Forma ORM
        //Delet Fin
	}
	
	public static void Editar(long id,String nombre){
		//Edit Inicio
        entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		//long id2 = 31;
		Categoria categoria2 = entityManager.find(Categoria.class, id);
		categoria2.setNombre(nombre);
        
		entityManager.getTransaction().commit();
        entityManager.close();
        //Edit Fin
	}

}
