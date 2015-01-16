package serpis.ad;

import static org.junit.Assert.*;

import org.junit.Test;

public class VectorTest {

	@Test
	public void testMin() {
		int[] v = new int[] {12,31,21,3,100,46};
		int minvalue = Vector.min(v);
		
		assertEquals(12,minvalue);
	}

}
