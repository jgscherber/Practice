package game;

import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.util.Random;
import java.awt.Color;

import javax.swing.JPanel;



public class Die extends JPanel {

	private static final long serialVersionUID = 1L;
	
	private static final int
						WIDTH = 60,
						HEIGHT = 60,
						STATE_AVAILABLE = 0,
						STATE_SELECTED = 1,
						STATE_HELD = 2;
	
	private int 
			value = 1,
			state = STATE_AVAILABLE;
	
	private Random rand = new Random();
	
	Die() {
		roll();
		addMouseListener(new MouseAdapter() {
			public void mouseReleased(MouseEvent e) {
				click();
			}
			
		});
	}
	
	Die(int value) { // for testing purposes
		this.value = value;
		
		addMouseListener(new MouseAdapter() {
			public void mouseReleased(MouseEvent e) {
				click();
			}
			
		});
	}
	
	private void click() {
		if(state == STATE_AVAILABLE) {
			state = STATE_SELECTED;
			repaint();
			return;
		}
		if(state == STATE_SELECTED) {
			state = STATE_AVAILABLE;
			repaint();
			return;
		}
	}
	
	public int roll() {
		value = (int)rand.nextInt(6)+1;
		repaint();
		return value;
	}
						
	@Override
	public Dimension getPreferredSize() {
		return new Dimension(WIDTH,HEIGHT);		
	}
	
	@Override
	public void paintComponent(Graphics g) {
		
		// fill in background
		switch(state) {
		case STATE_AVAILABLE:
			g.setColor(Color.WHITE);
			break;
		case STATE_SELECTED:
			g.setColor(Color.RED);
			break;
		case STATE_HELD:
			g.setColor(Color.LIGHT_GRAY);
			break;
		}
		
		g.fillRect(0,0,WIDTH, HEIGHT);
			
		// draw border
		g.setColor(Color.BLACK);
		g.drawRect(0, 0, WIDTH-1, HEIGHT-1);
		
		// draw dots
		switch(value) {
		case 5:
			drawDot(g, WIDTH/4, HEIGHT/4);
			drawDot(g, WIDTH-WIDTH/4, HEIGHT-HEIGHT/4);
		case 3:
			drawDot(g, WIDTH-WIDTH/4, HEIGHT/4);
			drawDot(g, WIDTH/4, HEIGHT-HEIGHT/4);
		case 1:
			drawDot(g, WIDTH/2, HEIGHT/2);
			break;
		case 6:
			drawDot(g, WIDTH/4, HEIGHT/2);
			drawDot(g, WIDTH-WIDTH/4, HEIGHT/2);
		case 4:
			drawDot(g, WIDTH/4, HEIGHT/4);
			drawDot(g, WIDTH-WIDTH/4, HEIGHT-HEIGHT/4);		
		case 2:
			drawDot(g, WIDTH-WIDTH/4, HEIGHT/4);
			drawDot(g, WIDTH/4, HEIGHT-HEIGHT/4);
		
		
		}
		
		
	}
	
	private void drawDot(Graphics g, int x, int y) {
		g.setColor(Color.BLACK);
		g.fillOval(x-5, y-5, 10	, 10);
	}
	
	
	// -- Getters
	
	public boolean isAvailable() {
		return(state == STATE_AVAILABLE);
	}
	
	public boolean isSelected() {
		return(state == STATE_SELECTED);
	}
	
	public boolean isHeld() {
		return(state == STATE_HELD);
	}
	
	public int getValue() {
		return value;
	}
	
	public void hold() {
		state = STATE_HELD;
		repaint();
	}
	
	public void makeAvailable() {
		state = STATE_AVAILABLE;
		repaint();
	}
}
