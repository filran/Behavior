
public class Programa implements Runnable{
	private int id;
	
	public Programa(int iidd)
	{
		this.id = iidd;
	}
	
	public void run()
	{
		for (int i=0; i<10; i++)
		{
			System.out.println( "Programa:" + this.id + " valor: " +i);
		}
	}
	
	
}
