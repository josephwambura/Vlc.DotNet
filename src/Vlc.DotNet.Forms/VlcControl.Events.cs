﻿using System;
using System.ComponentModel;

using Vlc.DotNet.Core;

namespace Vlc.DotNet.Forms
{
    public partial class VlcControl
    {
        private object myEventSyncLocker = new object();

        private void RegisterEvents()
        {
            myVlcMediaPlayer.Backward += OnBackwardInternal;
            myVlcMediaPlayer.Buffering += OnBufferingInternal;
            myVlcMediaPlayer.EncounteredError += OnEncounteredErrorInternal;
            myVlcMediaPlayer.EndReached += OnEndReachedInternal;
            myVlcMediaPlayer.Forward += OnForwardInternal;
            myVlcMediaPlayer.LengthChanged += OnLengthChangedInternal;
            myVlcMediaPlayer.MediaChanged += OnMediaChangedInternal;
            myVlcMediaPlayer.Opening += OnOpeningInternal;
            myVlcMediaPlayer.PausableChanged += OnPausableChangedInternal;
            myVlcMediaPlayer.Paused += OnPausedInternal;
            myVlcMediaPlayer.Playing += OnPlayingInternal;
            myVlcMediaPlayer.PositionChanged += OnPositionChangedInternal;
            myVlcMediaPlayer.ScrambledChanged += OnScrambledChangedInternal;
            myVlcMediaPlayer.SeekableChanged += OnSeekableChangedInternal;
            myVlcMediaPlayer.SnapshotTaken += OnSnapshotTakenInternal;
            myVlcMediaPlayer.Stopped += OnStoppedInternal;
            myVlcMediaPlayer.TimeChanged += OnTimeChangedInternal;
            myVlcMediaPlayer.TitleChanged += OnTitleChangedInternal;
            myVlcMediaPlayer.VideoOutChanged += OnVideoOutChangedInternal;
        }

        private void UnregisterEvents()
        {
            myVlcMediaPlayer.Backward -= OnBackwardInternal;
            myVlcMediaPlayer.Buffering -= OnBufferingInternal;
            myVlcMediaPlayer.EncounteredError -= OnEncounteredErrorInternal;
            myVlcMediaPlayer.EndReached -= OnEndReachedInternal;
            myVlcMediaPlayer.Forward -= OnForwardInternal;
            myVlcMediaPlayer.LengthChanged -= OnLengthChangedInternal;
            myVlcMediaPlayer.MediaChanged -= OnMediaChangedInternal;
            myVlcMediaPlayer.Opening -= OnOpeningInternal;
            myVlcMediaPlayer.PausableChanged -= OnPausableChangedInternal;
            myVlcMediaPlayer.Paused -= OnPausedInternal;
            myVlcMediaPlayer.Playing -= OnPlayingInternal;
            myVlcMediaPlayer.PositionChanged -= OnPositionChangedInternal;
            myVlcMediaPlayer.ScrambledChanged -= OnScrambledChangedInternal;
            myVlcMediaPlayer.SeekableChanged -= OnSeekableChangedInternal;
            myVlcMediaPlayer.SnapshotTaken -= OnSnapshotTakenInternal;
            myVlcMediaPlayer.Stopped -= OnStoppedInternal;
            myVlcMediaPlayer.TimeChanged -= OnTimeChangedInternal;
            myVlcMediaPlayer.TitleChanged -= OnTitleChangedInternal;
            myVlcMediaPlayer.VideoOutChanged -= OnVideoOutChangedInternal;
        }

        #region Backward event
        private void OnBackwardInternal(object sender, VlcMediaPlayerBackwardEventArgs e)
        {
            OnBackward();
        }

        [Category("Media Player")]
        public event EventHandler<VlcMediaPlayerBackwardEventArgs> Backward;

        public void OnBackward()
        {
            lock (myEventSyncLocker)
            {
                Backward?.Invoke(this, new VlcMediaPlayerBackwardEventArgs());
            }
        }
        #endregion

        #region Buffering event
        private void OnBufferingInternal(object sender, VlcMediaPlayerBufferingEventArgs e)
        {
            OnBuffering(e.NewCache);
        }

        [Category("Media Player")]
        public event EventHandler<VlcMediaPlayerBufferingEventArgs> Buffering;

        public void OnBuffering(float newCache)
        {
            lock (myEventSyncLocker)
            {
                Buffering?.Invoke(this, new VlcMediaPlayerBufferingEventArgs(newCache));
            }
        }
        #endregion

        #region Encountered Error event
        private void OnEncounteredErrorInternal(object sender, VlcMediaPlayerEncounteredErrorEventArgs e)
        {
            OnEncounteredError();
        }

        [Category("Media Player")]
        public event EventHandler<VlcMediaPlayerEncounteredErrorEventArgs> EncounteredError;

        public void OnEncounteredError()
        {
            lock (myEventSyncLocker)
            {
                EncounteredError?.Invoke(this, new VlcMediaPlayerEncounteredErrorEventArgs());
            }
        }
        #endregion

        #region EndReached event
        private void OnEndReachedInternal(object sender, VlcMediaPlayerEndReachedEventArgs e)
        {
            OnEndReached();
        }

        [Category("Media Player")]
        public event EventHandler<VlcMediaPlayerEndReachedEventArgs> EndReached;

        public void OnEndReached()
        {
            lock (myEventSyncLocker)
            {
                EndReached?.Invoke(this, new VlcMediaPlayerEndReachedEventArgs());
            }
        }
        #endregion

        #region Forward event
        private void OnForwardInternal(object sender, VlcMediaPlayerForwardEventArgs e)
        {
            OnForward();
        }

        [Category("Media Player")]
        public event EventHandler<VlcMediaPlayerForwardEventArgs> Forward;

        public void OnForward()
        {
            lock (myEventSyncLocker)
            {
                Forward?.Invoke(this, new VlcMediaPlayerForwardEventArgs());
            }
        }
        #endregion

        #region Length Changed event
        private void OnLengthChangedInternal(object sender, VlcMediaPlayerLengthChangedEventArgs e)
        {
            OnLengthChanged(e.NewLength);
        }

        [Category("Media Player")]
        public event EventHandler<VlcMediaPlayerLengthChangedEventArgs> LengthChanged;

        public void OnLengthChanged(long newLength)
        {
            lock (myEventSyncLocker)
            {
                LengthChanged?.Invoke(this, new VlcMediaPlayerLengthChangedEventArgs(newLength));
            }
        }
        #endregion

        #region Log event
        private object _logLocker = new object();

        private EventHandler<VlcMediaPlayerLogEventArgs> log;

        private void OnLogInternal(object sender, VlcMediaPlayerLogEventArgs args)
        {
            lock (this._logLocker)
            {
                if (this.log != null)
                {
                    this.log(sender, args);
                }
            }
        }

        /// <summary>
        /// The event that is triggered when a log is emitted from libVLC.
        /// Listening to this event will discard the default logger in libvlc.
        /// </summary>
        [Category("Media Player")]
        public event EventHandler<VlcMediaPlayerLogEventArgs> Log
        {
            add
            {
                lock (this._logLocker)
                {
                    this.log += value;
                }
                if (this.myVlcMediaPlayer != null)
                {
                    // Registers if not already done.
                    this.RegisterLogging();
                }
            }
            remove
            {
                lock (this._logLocker)
                {
                    this.log -= value;
                }
            }
        }
        #endregion

        #region Media Changed event
        private void OnMediaChangedInternal(object sender, VlcMediaPlayerMediaChangedEventArgs e)
        {
            OnMediaChanged(e.NewMedia);
        }

        [Category("Media Player")]
        public event EventHandler<VlcMediaPlayerMediaChangedEventArgs> MediaChanged;

        public void OnMediaChanged(VlcMedia newMedia)
        {
            lock (myEventSyncLocker)
            {
                MediaChanged?.Invoke(this, new VlcMediaPlayerMediaChangedEventArgs(newMedia));
            }
        }
        #endregion

        #region Opening event
        private void OnOpeningInternal(object sender, VlcMediaPlayerOpeningEventArgs e)
        {
            OnOpening();
        }

        [Category("Media Player")]
        public event EventHandler<VlcMediaPlayerOpeningEventArgs> Opening;

        public void OnOpening()
        {
            lock (myEventSyncLocker)
            {
                Opening?.Invoke(this, new VlcMediaPlayerOpeningEventArgs());
            }
        }
        #endregion

        #region Pausable Changed event
        private void OnPausableChangedInternal(object sender, VlcMediaPlayerPausableChangedEventArgs e)
        {
            OnPausableChanged(e.IsPaused);
        }

        [Category("Media Player")]
        public event EventHandler<VlcMediaPlayerPausableChangedEventArgs> PausableChanged;

        public void OnPausableChanged(bool isPaused)
        {
            lock (myEventSyncLocker)
            {
                PausableChanged?.Invoke(this, new VlcMediaPlayerPausableChangedEventArgs(isPaused));
            }
        }

        #endregion

        #region Paused event
        private void OnPausedInternal(object sender, VlcMediaPlayerPausedEventArgs e)
        {
            OnPaused();
        }

        [Category("Media Player")]
        public event EventHandler<VlcMediaPlayerPausedEventArgs> Paused;

        public void OnPaused()
        {
            lock (myEventSyncLocker)
            {
                Paused?.Invoke(this, new VlcMediaPlayerPausedEventArgs());
            }
        }
        #endregion

        #region Playing event
        private void OnPlayingInternal(object sender, VlcMediaPlayerPlayingEventArgs e)
        {
            OnPlaying();
        }

        [Category("Media Player")]
        public event EventHandler<VlcMediaPlayerPlayingEventArgs> Playing;

        public void OnPlaying()
        {
            lock (myEventSyncLocker)
            {
                Playing?.Invoke(this, new VlcMediaPlayerPlayingEventArgs());
            }
        }

        #endregion

        #region Position Changed event
        private void OnPositionChangedInternal(object sender, VlcMediaPlayerPositionChangedEventArgs e)
        {
            OnPositionChanged(e.NewPosition);
        }

        [Category("Media Player")]
        public event EventHandler<VlcMediaPlayerPositionChangedEventArgs> PositionChanged;

        public void OnPositionChanged(float newPosition)
        {
            lock (myEventSyncLocker)
            {
                PositionChanged?.Invoke(this, new VlcMediaPlayerPositionChangedEventArgs(newPosition));
            }
        }
        #endregion

        #region Scrambled Changed event
        private void OnScrambledChangedInternal(object sender, VlcMediaPlayerScrambledChangedEventArgs e)
        {
            OnScrambledChanged(e.NewScrambled);
        }

        [Category("Media Player")]
        public event EventHandler<VlcMediaPlayerScrambledChangedEventArgs> ScrambledChanged;

        public void OnScrambledChanged(int newScrambled)
        {
            lock (myEventSyncLocker)
            {
                ScrambledChanged?.Invoke(this, new VlcMediaPlayerScrambledChangedEventArgs(newScrambled));
            }
        }

        #endregion

        #region Seekable Changed event
        private void OnSeekableChangedInternal(object sender, VlcMediaPlayerSeekableChangedEventArgs e)
        {
            OnSeekableChanged(e.NewSeekable);
        }

        [Category("Media Player")]
        public event EventHandler<VlcMediaPlayerSeekableChangedEventArgs> SeekableChanged;

        public void OnSeekableChanged(int newSeekable)
        {
            lock (myEventSyncLocker)
            {
                SeekableChanged?.Invoke(this, new VlcMediaPlayerSeekableChangedEventArgs(newSeekable));
            }
        }
        #endregion

        #region Snapshot Taken event
        private void OnSnapshotTakenInternal(object sender, VlcMediaPlayerSnapshotTakenEventArgs e)
        {
            OnSnapshotTaken(e.FileName);
        }

        [Category("Media Player")]
        public event EventHandler<VlcMediaPlayerSnapshotTakenEventArgs> SnapshotTaken;

        public void OnSnapshotTaken(string fileName)
        {
            lock (myEventSyncLocker)
            {
                SnapshotTaken?.Invoke(this, new VlcMediaPlayerSnapshotTakenEventArgs(fileName));
            }
        }

        #endregion

        #region Time Changed event
        private void OnTimeChangedInternal(object sender, VlcMediaPlayerTimeChangedEventArgs e)
        {
            OnTimeChanged(e.NewTime);
        }

        [Category("Media Player")]
        public event EventHandler<VlcMediaPlayerTimeChangedEventArgs> TimeChanged;

        public void OnTimeChanged(long newTime)
        {
            lock (myEventSyncLocker)
            {
                TimeChanged?.Invoke(this, new VlcMediaPlayerTimeChangedEventArgs(newTime));
            }
        }
        #endregion

        #region Title Changed event
        private void OnTitleChangedInternal(object sender, VlcMediaPlayerTitleChangedEventArgs e)
        {
            OnTitleChanged(e.NewTitle);
        }

        [Category("Media Player")]
        public event EventHandler<VlcMediaPlayerTitleChangedEventArgs> TitleChanged;

        public void OnTitleChanged(int newTitle)
        {
            lock (myEventSyncLocker)
            {
                TitleChanged?.Invoke(this, new VlcMediaPlayerTitleChangedEventArgs(newTitle));
            }
        }
        #endregion

        #region Stopped event
        private void OnStoppedInternal(object sender, VlcMediaPlayerStoppedEventArgs e)
        {
            OnStopped();
        }

        [Category("Media Player")]
        public event EventHandler<VlcMediaPlayerStoppedEventArgs> Stopped;

        public void OnStopped()
        {
            lock (myEventSyncLocker)
            {
                Stopped?.Invoke(this, new VlcMediaPlayerStoppedEventArgs());
            }
        }
        #endregion

        #region Video Out Changed event
        private void OnVideoOutChangedInternal(object sender, VlcMediaPlayerVideoOutChangedEventArgs e)
        {
            OnVideoOutChanged(e.NewCount);
        }

        [Category("Media Player")]
        public event EventHandler<VlcMediaPlayerVideoOutChangedEventArgs> VideoOutChanged;

        public void OnVideoOutChanged(int newCount)
        {
            lock (myEventSyncLocker)
            {
                VideoOutChanged?.Invoke(this, new VlcMediaPlayerVideoOutChangedEventArgs(newCount));
            }
        }
        #endregion
    }
}
