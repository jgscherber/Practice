package mazegenerator;

import java.awt.BorderLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.BoxLayout;
import javax.swing.ButtonGroup;
import javax.swing.JButton;
import javax.swing.JDialog;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
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
	
	private boolean canceled = true;
	
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
		JPanel buttonPanel = new JPanel();
		add(buttonPanel, BorderLayout.PAGE_END);
		
		JButton okButton = new JButton("OK");
		okButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				close();
				
			}
		});
		
		buttonPanel.add(okButton);
		
		JButton cancelButton = new JButton("Cancel");
		cancelButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				setVisible(false);
				
			}
		});
		buttonPanel.add(cancelButton);
		
		getRootPane().setDefaultButton(okButton); // also works in a JFrame
	} // end optionsDialog()
	
	private void close() {
		// get entered values
		String rowsString = rowsField.getText();
		String colsString = colsField.getText();
		try{
			int newRows = Integer.parseInt(rowsString); // throws NumberFormatException
			int newCols = Integer.parseInt(colsString);
		
			// check entered values are valid
			if(newRows > 1 && newCols > 1) {
				rows = newRows;
				cols = newCols;
				if(mazeButton.isSelected()) type = MazeGenerator.TYPE_MAZE;
				else  type = MazeGenerator.TYPE_ANTIMAZE;
				setVisible(false); // same as closing for a dialog (only an object)
				canceled = false;
			} else {
				String message = "There must be more than one row and more than one column.";
				JOptionPane.showMessageDialog(this, message);
			}
		
		} catch(NumberFormatException e) {
			String message = "Rows and columns must be numbers.";
			JOptionPane.showMessageDialog(this, message);
		}
	
	} // end close()
	
	public int getRows() { return rows; }
	public int getColumns() { return cols;}
	public int getMazeType() {return type;}
	public boolean isCanceled() {return canceled;}
	
}// end class

//JDialog objects are modal by default. Opening a modal dialog stops the program until the 
//dialog is closed. Opening a non-modal dialog lets the program code continue running while 
//the dialog is open.
//
//Godtland, Annette. More Do-It-Yourself Java Games: An Introduction to Java Graphics and 
//Event-Driven Programming (Kindle Locations 4362-4363). Godtland Software Corporation. 
//Kindle Edition. 
