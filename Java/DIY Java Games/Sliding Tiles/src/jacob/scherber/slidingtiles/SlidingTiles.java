// no reason to have this many package levels...
package jacob.scherber.slidingtiles;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.EventQueue;
import java.awt.Graphics;
import java.awt.GridLayout;
import java.awt.Scrollbar;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.util.Random;

import javax.imageio.ImageIO;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.UIManager;

import jacob.scherber.mycomponents.TitleLabel;

public class SlidingTiles extends JFrame {
	
	private static final long serialVersionUID = 1L;
	
	// iamge variables
	private static final String FILENAME = "slidingTilesImage.jpg";
	private static final int 
						UP = 0, 
						DOWN=1, 
						LEFT = 2, 
						RIGHT=3,
						IMAGESIZE=200;
	
	private int gridSize = 3;
	private int tileSize = 200/gridSize;
	private BufferedImage image = null;
	
	
	
	private TileButton[][] tile = new TileButton[gridSize][gridSize];
	JPanel centerPanel = new JPanel();
	
	public SlidingTiles() {
		
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
		
		// menu bar
		JMenuBar menuBar = new JMenuBar();
		setJMenuBar(menuBar);
		
		JMenu fileMenu = new JMenu("File"); // needs String arg
		menuBar.add(fileMenu);
		JMenu sizeMenu = new JMenu("Size");
		menuBar.add(sizeMenu);
		
		JMenuItem openMenuItem = new JMenuItem("Open");
		fileMenu.add(openMenuItem);
		JMenuItem size3MenuItem = new JMenuItem("3 x 3");
		sizeMenu.add(size3MenuItem);
		JMenuItem size4MenuItem = new JMenuItem("4 x 4");
		sizeMenu.add(size4MenuItem);
		JMenuItem size5MenuItem = new JMenuItem("5 x 5");
		sizeMenu.add(size5MenuItem);
		
		openMenuItem.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				open();
				
			}
		});
		
		size3MenuItem.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent arg0) {
				setGridSize(3);
				
			}
		});
		
		size4MenuItem.addActionListener(new ActionListener() {
					
					@Override
					public void actionPerformed(ActionEvent arg0) {
						setGridSize(4);
						
					}
				});
		
		size5MenuItem.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent arg0) {
				setGridSize(5);
				
			}
		});
		
		// title
		TitleLabel title = new TitleLabel("Sliding Tiles");
		add(title,BorderLayout.PAGE_START);
		
		// main panel
		divideImage();

		
		// button panel
		JPanel buttonPanel = new JPanel();
		buttonPanel.setBackground(Color.BLACK);
		add(buttonPanel,BorderLayout.PAGE_END);
		
		JButton scrambleButton = new JButton("Scramble");
		scrambleButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				newGame();
				
			}
		});
		buttonPanel.add(scrambleButton);
		
	}
	
	private void setGridSize(int size) {
		
		gridSize = size;
		tileSize = IMAGESIZE / size;
		TileButton.setTileSizeAndMaxTiles(tileSize, gridSize);
		tile = new TileButton[gridSize][gridSize];
		divideImage();
		pack(); // repack the image to avoid uneven divisions of the IMAGESIZE leaving extra space
	}
	
	private void open() {
		JFileChooser chooser = new JFileChooser(); // can set default path here as String
		
		ImageFileFilter fileFilter = new ImageFileFilter();
		chooser.setFileFilter(fileFilter);
		
		int option = chooser.showOpenDialog(this); // this is the JFrame
		
		if(option==JFileChooser.APPROVE_OPTION) {
			File file = chooser.getSelectedFile();
			try {
				//image = ImageIO.read(file);
				BufferedImage newImage = ImageIO.read(file); // should only exist w/in this block
				
				int width = newImage.getWidth();
				int height = newImage.getHeight();
				width = Math.max(width, height);
				height = Math.max(width, height);
				
				// Returns: a Graphics2D, which can be used to draw into this image.
				Graphics g = image.getGraphics();
				// from, output size, input size, "observer"
				g.drawImage(newImage,0,0,IMAGESIZE, IMAGESIZE, 0,0,width,height,this);
				g.dispose();
				
				divideImage();
			}
			catch(Exception e) {
				String message = "Could not open file.";
				JOptionPane.showMessageDialog(this, message);
			}
			
		}
	}
	
	private void newGame() {
//		int imageId = 0;
//		for(int row = 0; row<gridSize; row ++) {
//			for( int col = 0; col<gridSize; col++) {
//				int x = tileSize * col;
//				int y = tileSize * row;
//				BufferedImage subimage = image.getSubimage(x, y, tileSize, tileSize);
//				ImageIcon imageIcon = new ImageIcon(subimage);
//				tile[row][col].setImage(imageIcon, imageId);
//				imageId++;
//			}
//		}
		divideImage();
		scramble();
		
	}
	
	
	private void divideImage() {
		
		centerPanel.setLayout(new GridLayout(gridSize,gridSize));
		add(centerPanel,BorderLayout.CENTER);
		int imageId = 0; // imageId instance varianle of TileButton
		
		centerPanel.removeAll(); // for recalling method, have to clear first
		for(int row = 0; row<gridSize; row ++) {
			for( int col = 0; col<gridSize; col++) {
				int x = tileSize * col;
				int y = tileSize * row;
				BufferedImage subimage = image.getSubimage(x, y, tileSize, tileSize);
				ImageIcon imageIcon = new ImageIcon(subimage);
				tile[row][col] = new TileButton(imageIcon, imageId, row, col);
				tile[row][col].addActionListener(new ActionListener() {
					
					@Override
					public void actionPerformed(ActionEvent e) {
						TileButton button = (TileButton)e.getSource();
						clickedTile(button); // needs to be defined
						
					}
				});
				centerPanel.add(tile[row][col]); // tile is a component (JButton)
				imageId++;
			}
		}
		
		centerPanel.revalidate(); // then redraw window
		scramble();
	}
	
	private void scramble() {
		int openRow = gridSize-1;
		int openCol = gridSize-1;
		
		Random rand = new Random();
		
		for(int i = 0; i<gridSize*25;i++) {
			int direction = rand.nextInt(4);
			switch(direction) {
			case UP: 
				if(openRow!=0) {
					tile[openRow][openCol].swap(tile[openRow-1][openCol]);
					openRow = openRow-1;
				}
				break;
			case DOWN:
				if(openRow!=gridSize-1) {
					tile[openRow][openCol].swap(tile[openRow+1][openCol]);
					openRow = openRow+1;
				}
				break;
			case LEFT:
				if(openCol!=0) {
					tile[openRow][openCol].swap(tile[openRow][openCol-1]);
					openCol = openCol-1;
				}
				break;
			case RIGHT:
				if(openCol!=gridSize-1) {
					tile[openRow][openCol].swap(tile[openRow][openCol+1]);
					openCol = openCol+1;
				}
				break;
			}
		}
	}
	
	// check if the imageIDs are in order
	private boolean imagesInOrder() {
		int id = 0;
		boolean inOrder=true;
		for(int i = 0; inOrder && i<gridSize; i++) {
			for(int j = 0; inOrder && j<gridSize; j++){
				int currentID = tile[i][j].getImageId();
				//System.out.println(currentID + " " + id);
				inOrder = currentID == id;
				id++;
				
			}
		}
		return inOrder;	
		
	}
	
	private void clickedTile(TileButton button) {
		int row = button.getRow();
		int col = button.getCol();
		// short certain eval will prevent out of index exception
		if(row != 0 && tile[row-1][col].hasNoImage()){
			button.swap(tile[row-1][col]);
		}
		else if (row != gridSize-1 && tile[row+1][col].hasNoImage()) {
			button.swap(tile[row+1][col]);
		}
		else if (col != 0 && tile[row][col-1].hasNoImage()) {
			button.swap(tile[row][col-1]);
		}
		else if (col!= gridSize-1 && tile[row][col+1].hasNoImage()){
			button.swap(tile[row][col+1]);
		}
		
		// once image is shown, no blank spaces available for swaps
		if(imagesInOrder()) tile[gridSize-1][gridSize-1].showImage();
		
		
	}
	
	public static void main(String[] args) {
		
//		 this has to be before eventqueue call????
		try {
//			String className = UIManager.getCrossPlatformLookAndFeelClassName();
			String className = UIManager.getSystemLookAndFeelClassName();
			UIManager.setLookAndFeel(className);
		}
		catch(Exception e){}
		
		
		EventQueue.invokeLater(new Runnable() {
			
			@Override
			public void run() {
				
				new SlidingTiles();
			}
		});
		
		
		
	}

}
