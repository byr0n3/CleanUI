export {};

declare global {
	interface Window {
		Modal: {
			open(id: string): void;
			close(id: string): void;
		};
	}
}
