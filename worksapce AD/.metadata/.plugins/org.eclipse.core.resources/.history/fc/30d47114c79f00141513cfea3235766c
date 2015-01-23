package serpis.ad;

import javax.persistence.EntityManager;
import javax.persistence.Persistence;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;



public class HibernateCategoria {
	private static EntityManagerFactory entityManagerFactory;
	
	public static void main(String [] args){
		
		entityManagerFactory = Persistence.createEntityManagerFactory("serpis.ad.jpa.mysql");
		// Insert Inicio
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		//entityManager.persist( new Categoria( "asdqewa"  ));
		//entityManager.persist( new Categoria( "asdqwe"   ));
		Categoria categoriaObj = new Categoria();
		categoriaObj.setNombre("asjdjko");
		entityManager.persist(categoriaObj);
		entityManager.getTransaction().commit();
		entityManager.close();
		// Insert Fin
		
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
        
        //Delet Inicio
        //Delet Fin
        
        //Edit Inicio
        //Edit Fin
        
        entityManagerFactory.close();
		
	}

}
