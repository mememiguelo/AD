package serpis.ad;

public class Vector {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int[] v = {12,31,21,3};
		
		int resultado = min(v);
		System.out.println("el numero menor es "+resultado);

	}
	
	public static int min(int[] v){
		int valorMin=v[0];
		
		for(int i=0;i<v.length;i++){
			if(v[i]<valorMin){
				valorMin=v[i];
			}
		}
		
		return valorMin;
	}

}
