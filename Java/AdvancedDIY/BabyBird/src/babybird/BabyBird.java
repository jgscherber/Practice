package babybird;

import jacob.scherber.mycomponents.ScorePanel;
import jacob.scherber.mycomponents.TitleLabel;

import javax.swing.*;
import java.awt.*;

public class BabyBird extends JFrame{

    public static void main(String[] args) {
        try {
            String className = UIManager.getCrossPlatformLookAndFeelClassName();
            UIManager.setLookAndFeel(className);
        } catch (Exception e) {  }

        EventQueue.invokeLater(new Runnable() {
            @Override
            public void run() {
                new BabyBird();
            }
        });
    }

    public BabyBird() {
        initGUI();
        setTitle("BabyBird");
        setResizable(false);
        setVisible(true);
        pack();
        setLocationRelativeTo(null);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    }

    private ScorePanel scorePanel = new ScorePanel(0, Color.GREEN);
    private FlightPanel flightPanel = new FlightPanel(this);

    private void initGUI() {
        TitleLabel titleLabel = new TitleLabel("Baby Bird");
        add(titleLabel, BorderLayout.PAGE_START);
        // main panel
        JPanel mainPanel = new JPanel();
        mainPanel.setBackground(Color.GREEN);
        mainPanel.setLayout(new BoxLayout(mainPanel, BoxLayout.Y_AXIS));
        add(mainPanel, BorderLayout.CENTER);
        // score panel
        mainPanel.add(scorePanel);

        // flight panel
        mainPanel.add(flightPanel);

        // bottom panel

        // bird nest panel
    }

}
