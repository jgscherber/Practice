package mazegenerator;

import java.awt.BorderLayout;

import javax.swing.BoxLayout;
import javax.swing.ButtonGroup;
import javax.swing.JDialog;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JRadioButton;
import javax.swing.JTextField;

public class OptionsDialog extends JDialog {

	private static final long serialVersionUID = 1L;

	private int 
			rows = 0,
			cols = 0,
			type = 0;
	
	private JTextField 
			rowsField = new JTextField(3),
			colsField  = new JTextField(3);
	
	private JRadioButton 
			mazeButton = new JRadioButton("Maze"),
			antiMazeButton = new JRadioButton("Anti-Maze");
	
	public OptionsDialog(int rows, int cols, int type) {
		this.rows = rows;
		this.cols = cols;
		this.type = type;		
		setTitle("Maze Generator Options");
		
		// main panel
		JPanel mainPanel = new JPanel();
		mainPanel.setLayout(new BoxLayout(mainPanel, BoxLayout.Y_AXIS)); // container is mainPanel, not OptionsDialog
		add(mainPanel, BorderLayout.CENTER);
		
		JLabel rowsLabel = new JLabel("Rows");
		mainPanel.add(rowsLabel);
		
		rowsField.setText("" + rows);		
		mainPanel.add(rowsField);
		
		JLabel colsLabel = new JLabel("Cols");
		mainPanel.add(colsLabel);
		
		colsField.setText(""+cols);
		mainPanel.add(colsField);
		
		JLabel typeLabel = new JLabel("Maze Type: ");
		mainPanel.add(typeLabel);
		
		mainPanel.add(mazeButton);
		mainPanel.add(antiMazeButton);
		
		ButtonGroup buttonGroup = new ButtonGroup(); // used to make only one of the two buttons selectable at a time
		buttonGroup.add(antiMazeButton);
		buttonGroup.add(mazeButton);
		
		if(type == MazeGenerator.TYPE_ANTIMAZE) antiMazeButton.setSelected(true);
		else mazeButton.setSelected(true);
		
		// button panel
		
	}
	
}
