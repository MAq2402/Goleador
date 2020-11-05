import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pomodoro',
  templateUrl: './pomodoro.component.html',
  styleUrls: ['./pomodoro.component.scss']
})
export class PomodoroComponent implements OnInit {

  shortBreak = 5;
  longBreak = 10;
  pomodoro = 25;
  currentTimerType = this.pomodoro;
  timerValueMinutes = this.currentTimerType;
  timerValueSeconds = 0;
  interval;
  countingDown = false;
  constructor() {}

  ngOnInit() {
  }

  play() {
    if (!this.countingDown) {
      this.countingDown = true;
      this.interval = setInterval(() => {
        this.timerValueSeconds -= 1;
        if (this.timerValueSeconds < 0) {
          this.timerValueSeconds = 59;
          this.timerValueMinutes -= 1;
        }
        if (this.timerValueMinutes === 0 && this.timerValueSeconds === 0) {
          this.stop();
          this.playSound();
        }
      }, 1000);
    }
  }

  private playSound() {
    const audio = new Audio();
    audio.src = 'assets/audio/alarm.wav';
    audio.load();
    audio.play();
  }

  stop() {
    clearInterval(this.interval);
    this.countingDown = false;
  }

  reset(value: number = null) {
    this.timerValueMinutes = value ? value : this.currentTimerType;
    this.currentTimerType = this.timerValueMinutes;
  }
}
