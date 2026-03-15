export {};

declare global {
	interface Window {
		Modal: {
			open(id: string): void;
			close(id: string): void;
		};
		Tooltip: {
			register(tooltip: HTMLElement): void;
			show(id: string): void;
			hide(id: string): void;
		}
	}
}
