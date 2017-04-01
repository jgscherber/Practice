package mytimer;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.FontMetrics;
import java.awt.Graphics;

import javax.swing.JOptionPane;
import javax.swing.JPanel;

public class TimerPanel extends JPanel implements Runnable {

	private static final long serialVersionUID = 1L;

	private int width = 150;
	private int height = 24;
	private String timeString = "00:00:00";
	private long time = 10;
	
	private Thread timerThread;
	
	public TimerPanel(long time, Font font) {
		this.time = time;
		setFont(font);
		setTime(time);
		height = font.getSize();
		FontMetrics fm = getFontMetrics(font);
		width = fm.stringWidth(timeString);
		
	}
	
	// mutators
	
	public long getTime() {	return time; }
	
	public void setTime(long time) {
		this.time = time;
		
		long h = time / (60 * 60);
		long m = (time / 60 ) % 60;
		long s = time % 60;
		
		timeString = String.format("%02d:%02d:%02d",h,m,s);
		repaint();
	}
	
	
	// threading code
	
	public void start() { 
		// if allow thread creation when one exists, can start multiple threads each time it's clicked
		// stopping and restarting thread decrements causes run() to be started repeatedly
		if(timerThread == null 
				|| !timerThread.isAlive()) { 
			timerThread = new Thread(this);
			// JVM calls the run() method of the Runnable on a new thread
			// timerPanel has the thread sleep while the other thread continues
			timerThread.start(); 
		}
	}
	
	public void run() {
		while(time > 0) {
			try {
				Thread.sleep(1000);
			} catch (InterruptedException e) { return; } // thrown when the interrupt() is called below
			time -= 1;
			setTime(time);

			
		}
		timesUp();
	}

	public void stop() {
		if(timerThread != null) {timerThread.interrupt(); }		
	}
	
	// overrides
	
	@Override
	protected void paintComponent(Graphics g) {
		super.paintComponent(g); // why nee super this time??
		
		g.setColor(Color.BLACK);
		g.drawString(timeString, 0, height); // (0,0) must be at bottom-left
	}
	
	@Override
	public Dimension getPreferredSize() { return new Dimension(width,height); }
	
	
	
	protected void timesUp() { // why not private?
		String message = "Time's up!";
		JOptionPane.showMessageDialog(this, message);		
	}	

} // end class
