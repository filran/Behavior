
public class Teste {
	public static void main(String[] args) throws InterruptedException
	{
		Programa p1 = new Programa(1);
		Programa p2 = new Programa(2);
		
		Thread t1 = new Thread(p1);
		t1.start();
		
		Thread t2 = new Thread(p2);
		t2.sleep(10000);
		t2.start();
	}
}
