package mytimer;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.UIManager;

import jacob.scherber.mycomponents.TitleLabel;

public class MyTimer extends JFrame { private static final long serialVersionUID = 1L;
	
	private Font font = new Font(Font.DIALOG, Font.BOLD, 36);
	private TimerPanel timerPanel = new TimerPanel(0, font);

	public MyTimer() {
		initGUI();
		
		setTitle("My Timer");
		setResizable(false);
		setLocationRelativeTo(null);
		
		setVisible(true);
		setDefaultCloseOperation(EXIT_ON_CLOSE); // static variable of the super class
		
		pack();		
	}
	
	private void initGUI() {
		
		// title label
		TitleLabel titleLabel = new TitleLabel("My Timer");
		add(titleLabel, BorderLayout.PAGE_START);
		
		// center panel
		JPanel centerPanel = new JPanel();
		add(centerPanel, BorderLayout.CENTER);
		centerPanel.add(timerPanel);
		
		centerPanel.setBackground(Color.LIGHT_GRAY);
		timerPanel.setBackground(Color.LIGHT_GRAY);
		
		// Button Panel
		JPanel buttonPanel = new JPanel();
		add(buttonPanel, BorderLayout.PAGE_END);
		
		buttonPanel.setBackground(Color.BLACK);
		
		JButton startButton = new JButton("Start");		
		buttonPanel.add(startButton);
		
		JButton stopButton = new JButton("Stop");		
		buttonPanel.add(stopButton);
		
		JButton hoursButton = new JButton("Hour");
		JButton minutesButton = new JButton("Minute");
		JButton secondsButton = new JButton("Second");
		buttonPanel.add(hoursButton);
		buttonPanel.add(minutesButton);
		buttonPanel.add(secondsButton);
		
		JButton clearButton = new JButton("Clear");
		buttonPanel.add(clearButton);
		
		// action listeners
		clearButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				timerPanel.setTime(0);				
			}
		});
		
		
		hoursButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				addAnHour();
				
			}
		});
		
		minutesButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				addAnMinute();
				
			}
		});
		
		secondsButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				addASecond();
				
			}
		});
		
		stopButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				stop();				
			}
		});
		
		startButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				start();
				
			}
		});
		
		
	} // end initGUI()
	
	private void addASecond() {
		long time = timerPanel.getTime();
		time += 1;
		timerPanel.setTime(time);		
	}
	
	private void addAnMinute() {
		long time = timerPanel.getTime();
		time += 60;
		timerPanel.setTime(time);		
	}
	
	private void addAnHour() {
		long time = timerPanel.getTime();
		time += (60 * 60);
		timerPanel.setTime(time);		
	}

	private void stop() {
		timerPanel.stop();
		
	}

	private void start() {
		timerPanel.start();
		
	}

	public static void main(String[] args) {
		
		String className = UIManager.getCrossPlatformLookAndFeelClassName();
		try {
			UIManager.setLookAndFeel(className);
		} catch(Exception e) {}
		
		EventQueue.invokeLater(new Runnable() {
			
			@Override
			public void run() {
				new MyTimer();
				
			}
		});
		
	}

}
