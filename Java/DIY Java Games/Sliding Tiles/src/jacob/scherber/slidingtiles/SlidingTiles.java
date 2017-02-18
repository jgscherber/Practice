// no reason to have this many package levels...
package jacob.scherber.slidingtiles;

import java.awt.BorderLayout;
import java.awt.EventQueue;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.UIManager;

import jacob.scherber.mycomponents.TitleLabel;

public class SlidingTiles extends JFrame {
	
	private static final long serialVersionUID = 1L;
	
	// iamge variables
	private static final String FILENAME = "slidingTilesImage.jpg";
	private int tileSize = 50;
	private int gridSize = 4;
	private BufferedImage image = null;
	
	private TileButton[][] tile = new TileButton[gridSize][gridSize];
	JPanel centerPanel = new JPanel();
	
	public SlidingTiles(){
		TileButton.setTileSizeAndMaxTiles(tileSize, (int)Math.pow(gridSize, 2));
		
		try {
			// top is the root folder
			image = ImageIO.read(new File("src/"+FILENAME));
		
			initGUI();
			setTitle("Sliding Tiles");
			setVisible(true);
			setResizable(false);
			setLocationRelativeTo(null);
			setDefaultCloseOperation(EXIT_ON_CLOSE);
			pack();
		}
		catch (IOException e) {
			String message = "Could not open file.";
			JOptionPane.showMessageDialog(this, message);
		}
	}
	
	public void initGUI() {
		TitleLabel title = new TitleLabel("Sliding Tiles");
		add(title,BorderLayout.PAGE_START);
		
		// main panel
		divideImage();
		
		
		// button panel
		
		
	}
	
	private void divideImage() {
		
		centerPanel.setLayout(new BorderLayout(gridSize,gridSize));
		
	}
	
	
	public static void main(String[] args) {
		
		EventQueue.invokeLater(new Runnable() {
			
			@Override
			public void run() {
				new SlidingTiles();
				
			}
		});
		
		
		try {
			String className = UIManager.getCrossPlatformLookAndFeelClassName();
			UIManager.setLookAndFeel(className);
		}
		catch(Exception e){}
	}

}
