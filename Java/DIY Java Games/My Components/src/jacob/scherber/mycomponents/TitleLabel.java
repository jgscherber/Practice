package jacob.scherber.mycomponents;

import java.awt.Color;
import java.awt.Font;

import javax.swing.JLabel;

public class TitleLabel extends JLabel {

	private static final long serialVersionUID = 1L;
	
	public TitleLabel(String title) {
		Font font = new Font(Font.SERIF, Font.BOLD, 32);
		this.setFont(font);
		this.setBackground(Color.BLACK);
		this.setForeground(Color.WHITE);
		this.setOpaque(true);
		this.setHorizontalAlignment(JLabel.CENTER);
		this.setText(title);
		
		
	}
	
	
}
