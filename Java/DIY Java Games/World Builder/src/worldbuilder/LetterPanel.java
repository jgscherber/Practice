package worldbuilder;

import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;
import javax.swing.JOptionPane;
import javax.swing.JPanel;

public class LetterPanel extends JPanel {
	private static final long serialVersionUID = 1L;
	
	private static final Color BROWN = new Color(49,22,3); // RGB
	
	private static final String IMAGENAME = "WoodTile.jpg"; 
	
	private String letter = "";
	
	private int 
			points = -1,
			size = 40;
	
	private BufferedImage image = null;
	
	private Font 
			bigFont = new Font(Font.DIALOG,Font.BOLD, 30),
			smallFont = new Font(Font.DIALOG,Font.BOLD, 12);
	
	
	public LetterPanel() {
		this("",-1); // calls more general constructor
	}
	
	public LetterPanel(String letter, int points) {
		this.letter = letter;
		this.points = points;
		initPanel();

	}
	
	private void initPanel() {
		// get image if needed
		if(image == null) {
			try{
				image = ImageIO.read(new File(IMAGENAME));
			} catch(IOException e) {
				String message = "File not found";
				JOptionPane.showMessageDialog(null, message); // JPanel doesn't extend component
			}
		}
		
		// paint the letter panel
		
		
		
		
	} // end initPanel()
	
	@Override
	public void paintComponent(Graphics g) {
		if(letter.length() == 0) {
			g.setColor(BROWN);
			g.fillRect(0,0, size, size);
		} else {
			if(image == null) {
				g.setColor(Color.WHITE);
				g.fillRect(0,0, size, size);
			} else {
				g.drawImage(image, 0, 0, this);
			}
			g.setColor(Color.BLACK);
			g.drawRect(0, 0, size-1, size-1);
		}
	}

} // end class
